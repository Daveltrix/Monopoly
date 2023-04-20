using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CPokemon
    {
        public String Name { get; set; }
        public Int32 Value { get; set; }
        public String Color { get; set; }
        public Boolean Sold { get; set; }
        public String Trainer { get; set; }

        public CPokemon() { }

        public CPokemon (string name, int value, string color, bool sold)
        {
            this.Name = name;
            this.Value = value;
            this.Color = color;
            this.Sold = sold;
        }
    }
}
