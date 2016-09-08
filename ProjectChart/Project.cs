using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectChart
{
    class Project
    {
        public DataSet data = new DataSet();
        private string name;
        private DateTime start, end;
        private object pptxml;


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

        public object PPTXML
        {
            get
            {
                return data.Tables["Project"].Rows[0].Field<object>("Powerpoint");
            }
            set
            {
                var temp = data.Tables["Project"].Rows[0];
                temp.BeginEdit();
                temp.SetField("Powerpoint", value);
                temp.EndEdit();
            }
        }

        public Project()
        {
            data.ReadXmlSchema(@"ProjectData.xsd");
            data.Tables["Project"].Rows.Add(data.Tables["Project"].NewRow());
        }

        
        
    }
}
