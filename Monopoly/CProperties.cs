﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CProperties
    {
        public String Name { get; set; }
        public Int32 Value { get; set; }
        public String Color { get; set; }
        public Boolean Turn { get; set; }

        public CProperties() { }

        public CProperties (string name, int value, string color, bool turn)
        {
            Name = name;
            Value = value;
            Color = color;
            Turn = turn;
        }
    }
}
