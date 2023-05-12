using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CAttack
    {
        public String? NameAttack { get; set; }
        public String? Type { get; set; }
        public Int32 Power { get; set; }

        public CAttack() { }

        public CAttack(String _mNameAttack, String _mType, Int32 _mPower) 
        {
            this.NameAttack = _mNameAttack;
            this.Type = _mType;
            this.Power = _mPower;
        }
    }
}
