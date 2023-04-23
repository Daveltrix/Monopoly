using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CBox
    {
        public CBox(String _mName, Int32 _mPosition, String _NameBox, String _mBoxType, Int32 BoxPoke) 
        {
            this.Name = _mName;
            this.Position = _mPosition;
            this.NameBox = _NameBox;
            this.BoxType = _mBoxType;
            this.BoxPoke = BoxPoke;
        }



        public String Name { get; set; }
        public Int32 Position { get; set; }
        public String NameBox { get; set; }
        public String BoxType { get; set; }
        public Int32 BoxPoke { get; set; }
    }
}
