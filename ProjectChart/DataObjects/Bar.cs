using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChart.DataObjects
{
    public class Bar 
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Bar(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
