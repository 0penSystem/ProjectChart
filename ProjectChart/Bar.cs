using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChart
{
    class Bar
    {
        //private
        private List<Event> events;


        //props
        public string Name
        {
            get; set;
        }


        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public List<Event> Events
        {
            get
            {
                return events;
            }
        }

        public Bar()
        {
            events = new List<Event>();
        }

        //methods
        public void AddEvent(Event e)
        {
            events.Add(e);
        }


    }
}
