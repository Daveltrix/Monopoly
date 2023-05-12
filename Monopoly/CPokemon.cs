using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CPokemon
    {
        public String? Name { get; set; }
        public Int32 Value { get; set; }
        public String? Color { get; set; }
        public Boolean Sold { get; set; }
        public String? Trainer { get; set; }
        public Int32 Level { get; set; }
        public Int32 MaxNum { get; set; }
        public List<CAttack>? Attacks { get; set; }

        public CPokemon() { }

        public CPokemon (String _mName, Int32 _mValue, String _mColor, Boolean _mSold, Int32 _mLevel, Int32 _mMaxNum, List<CAttack> _listAttack)
        {
            this.Name = _mName;
            this.Value = _mValue;
            this.Color = _mColor;
            this.Sold = _mSold;
            this.Level = _mLevel;
            this.MaxNum = _mMaxNum;
            this.Attacks = _listAttack;
        }

    }
}
