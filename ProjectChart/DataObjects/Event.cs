using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChart.DataObjects
{
    public class Event
    {
        public int Id { get; private set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Bar Parent { get; set; }
        public int ParentID { get; set; }
        public EventShape Shape { get; set; } = EventShape.Arrow;
        public EventLocation Location { get; set; } = EventLocation.Above;

        public Event (int id) { Id = id; }


        public enum EventShape
        {
            Arrow, Triangle, Diamond, Star
        }

        public enum EventLocation
        {
            Above, Below
        }
    }


}
