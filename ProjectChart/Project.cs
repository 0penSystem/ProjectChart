using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace ProjectChart
{
    class Project
    {
        public DataSet data;
        private string name;
        private DateTime start, end;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField("Project Name", value);
                temp.EndEdit();

            }
        }

        public DateTime StartDate
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField("Start Date", value);
                temp.EndEdit();
            }
        }

        public DateTime EndDate
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField("End Date", value);
                temp.EndEdit();
            }
        }

        public Project()
        {
            data = new DataSet();
            data.ReadXmlSchema(@"ProjectData.xsd");
            data.Tables["Project"].Rows.Add(data.Tables["Project"].NewRow());
        }

        public Project(string fileName)
        {
            data = new DataSet();
            data.ReadXmlSchema(@"ProjectData.xsd");
            data.ReadXml(fileName);
        }

        public Project(XmlReader x)
        {
            data = new DataSet();
            data.ReadXmlSchema(@"ProjectData.xsd");
            data.ReadXml(x);
        }


    }
}
