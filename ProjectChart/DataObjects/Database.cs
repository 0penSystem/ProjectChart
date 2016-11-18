using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectChart.DataObjects
{
    public class Database
    {
        public DataSet data = new DataSet();

        #region Public Project Properties

        public string Name
        {
            get
            {
                return data.Tables["Project"].Rows[0].Field<string> ("Project Name");
            }
            set
            {
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField ("Project Name", value);
                temp.EndEdit();

            }
        }

        public DateTime StartDate
        {
            get
            {
                return data.Tables["Project"].Rows[0].Field<DateTime> ("Start Date");
            }
            set
            {
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField ("Start Date", value);
                temp.EndEdit();
            }
        }

        public DateTime EndDate
        {
            get
            {
                return data.Tables["Project"].Rows[0].Field<DateTime> ("End Date");
            }
            set
            {
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField ("End Date", value);
                temp.EndEdit();
            }
        }
        #endregion

        #region Constructors


        public Database()
        {

            data = new DataSet();
            data.ReadXmlSchema (@"ProjectData.xsd");
            data.Tables["Project"].Rows.Add (data.Tables["Project"].NewRow());
        }

        public Database (string fileName)
        {
            data = new DataSet();
            data.ReadXmlSchema (@"ProjectData.xsd");
            data.ReadXml (fileName);
        }

        public Database (XmlReader x)
        {
            data = new DataSet();
            data.ReadXmlSchema (@"ProjectData.xsd");
            data.ReadXml (x);
        }

        #endregion

        #region Import XML
        public bool ImportXML (string fileName)
        {
            var tempdata = new DataSet();
            tempdata.ReadXmlSchema (@"ProjectData.xsd");
            tempdata.ReadXml (fileName);
            return ImportHelper (tempdata);
        }

        public bool ImportXML (XmlReader x)
        {
            var tempdata = new DataSet();
            tempdata.ReadXmlSchema (@"ProjectData.xsd");
            tempdata.ReadXml (x);
            return ImportHelper (tempdata);
        }

        private bool ImportHelper (DataSet Import)
        {
            try
            {
                var bars = from b in Import.Tables["Bars"].AsEnumerable() select new Bar (-1) { Name = b.Field<string> ("Bar Name"), Start = b.Field<DateTime> ("Start Date"), End = b.Field<DateTime> ("End Date") };

                foreach (var bar in bars)
                {
                    addBar (bar);
                }

                var events = from e in Import.Tables["Events"].AsEnumerable() select new Event (-1) { Date = e.Field<DateTime> ("Event Date"), ParentID = -1, Location = (Event.EventLocation) (e.Field < int?> ("Location") ?? 0), Shape = (Event.EventShape) (e.Field < int?> ("Shape") ?? 0), Text = e.Field<string> ("Event Name") };

                foreach (var e in events)
                {
                    addEvent (e);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        #endregion


        #region Bar Methods
        public Bar getBar (int id)
        {
            var query = from DataRow d in data.Tables["Bars"].AsEnumerable() where d.Field<int> ("BarID") == id select new Bar (d.Field<int> ("BarId")) { Name = d.Field<string> ("Bar Name"), Start = d.Field<DateTime> ("Start Date"), End = d.Field<DateTime> ("End Date") };

            return query.FirstOrDefault();
        }

        public IEnumerable<Bar> getBars()
        {
            var query = from DataRow d in data.Tables["Bars"].AsEnumerable() select new Bar (d.Field<int> ("BarId")) { Name = d.Field<string> ("Bar Name"), Start = d.Field<DateTime> ("Start Date"), End = d.Field<DateTime> ("End Date") };

            List<Bar> list = new List<Bar>();

            foreach (Bar b in query)
            {
                list.Add (b);
            }

            return list;

        }

        public void deleteBar (Bar bar)
        {
            var existing = from DataRow d in data.Tables["Bars"].AsEnumerable() where d.Field<int> ("BarId") == bar.Id select d;

            if (!existing.Any())
            {
                //no previously existing bar matches. Throw error.
                throw new Exception ("No such bar to delete.");
            }
            else
            {
                var toUpdate = existing.FirstOrDefault();
                toUpdate.Delete();
            }
        }



        public void addBar (Bar bar)
        {
            var newRow = data.Tables["Bars"].NewRow();
            newRow.SetField ("Bar Name", bar.Name);
            newRow.SetField ("Start Date", bar.Start);
            newRow.SetField ("End Date", bar.End);

            data.Tables["Bars"].Rows.Add (newRow);
        }



        public void updateBar (Bar bar)
        {
            var existing = from DataRow d in data.Tables["Bars"].AsEnumerable() where d.Field<int> ("BarId") == bar.Id select d;

            if (!existing.Any())
            {
                //no previously existing bar matches. Throw error.
                throw new Exception ("No such bar to update.");
            }
            else
            {
                var toUpdate = existing.FirstOrDefault();
                toUpdate.BeginEdit();
                toUpdate.SetField ("Bar Name", bar.Name);
                toUpdate.SetField ("Start Date", bar.Start);
                toUpdate.SetField ("End Date", bar.End);
                toUpdate.EndEdit();
            }

        }
        #endregion

        #region Event Methods
        public void deleteEvent (Event e)
        {
            var existing = from DataRow d in data.Tables["Events"].AsEnumerable() where d.Field<int> ("EventId") == e.Id select d;

            if (!existing.Any())
            {
                //no previously existing bar matches. Throw error.
                throw new Exception ("No such event to delete.");
            }
            else
            {
                var toUpdate = existing.FirstOrDefault();
                toUpdate.Delete();
            }
        }


        public IEnumerable<Event> getEvents()
        {





            var parent = from DataRow e in data.Tables["Events"].AsEnumerable()
                         where !e.IsNull ("ParentBar")
                         select new Event (e.Field<int> ("EventId"))
            {
                Text = e.Field<string> ("Event Name"),
                Date = e.Field<DateTime> ("Event Date"),
                ParentID = e.Field<int> ("ParentBar"),
                Parent = getBar (e.Field<int> ("ParentBar")),
                Location = !e.IsNull ("Location") ? (Event.EventLocation) e.Field<int> ("Location") : Event.EventLocation.Above,
                Shape = !e.IsNull ("Shape") ? (Event.EventShape) e.Field<int> ("Shape") : Event.EventShape.Arrow
            };
            var noParent = from DataRow e in data.Tables["Events"].AsEnumerable()
                           where e.IsNull ("ParentBar")
                           select new Event (e.Field<int> ("EventId"))
            {
                Text = e.Field<string> ("Event Name"),
                Date = e.Field<DateTime> ("Event Date"),
                ParentID = -1,
                Location = !e.IsNull ("Location") ? (Event.EventLocation) e.Field<int> ("Location") : Event.EventLocation.Above,
                Shape = !e.IsNull ("Shape") ? (Event.EventShape) e.Field<int> ("Shape") : Event.EventShape.Arrow
            };


            List<Event> list = new List<Event>();

            foreach (Event e in noParent.Concat (parent))
            {
                list.Add (e);
            }

            return list;

        }

        public void updateEvent (Event newEvent)
        {
            Console.Out.WriteLine ($"{newEvent.ParentID}");

            var existing = from DataRow d in data.Tables["Events"].AsEnumerable() where d.Field<int> ("EventId") == newEvent.Id select d;

            if (!existing.Any())
            {
                //no previously existing bar matches. Throw error.
                throw new Exception ("No such event to update.");
            }
            else
            {
                var toUpdate = existing.FirstOrDefault();
                toUpdate.BeginEdit();
                toUpdate.SetField ("Event Name", newEvent.Text);
                toUpdate.SetField ("Event Date", newEvent.Date);
                toUpdate.SetField ("Shape", (int) newEvent.Shape);
                toUpdate.SetField ("Location", (int) newEvent.Location);

                if (newEvent.ParentID >= 0)
                {
                    toUpdate.SetField ("ParentBar", newEvent.ParentID);
                }
                else
                {
                    toUpdate["ParentBar"] = DBNull.Value;
                    //toUpdate.SetField("ParentBar", DBNull.Value);
                }

                toUpdate.EndEdit();
                toUpdate.AcceptChanges();
            }
        }


        public void addEvent (Event newEvent)
        {
            var newRow = data.Tables["Events"].NewRow();
            newRow.SetField ("Event Name", newEvent.Text);
            newRow.SetField ("Event Date", newEvent.Date);

            if (newEvent.ParentID >= 0)
            {
                newRow.SetField ("ParentBar", newEvent.ParentID);
            }

            newRow.SetField ("Shape", (int) newEvent.Shape);
            newRow.SetField ("Location", (int) newEvent.Location);
            data.Tables["Events"].Rows.Add (newRow);
        }


        #endregion



    }

}
