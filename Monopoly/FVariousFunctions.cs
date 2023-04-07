using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class FVariousFunctions
    {
        public FVariousFunctions() { }

        public static Int32 LanzarDado()
        {
            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, 7);
            return RandomNumber;
        }
    }
}
