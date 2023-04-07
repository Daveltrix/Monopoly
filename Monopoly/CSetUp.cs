using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CSetUp
    {  
        public CSetUp() 
        {
            _LClayers = new List<CPlayers>();
            _LProperties = new List<CProperties>();
        }

        public List<CPlayers> _LClayers { get; set; }
        public List<CProperties> _LProperties { get;  set; }




        public void AddlistPlayers(CPlayers Players)
        {
            _LClayers.Add(Players);
        }



        public void AddlistProperties(CProperties Property)
        {
            _LProperties.Add(Property);
        }

        

    }
}
