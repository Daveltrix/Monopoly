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
            _LPokemon = new List<CPokemon>();
        }

        public List<CPlayers> _LClayers { get; set; }
        public List<CPokemon> _LPokemon { get;  set; }




        public void AddlistPlayers(CPlayers Players)
        {
            _LClayers.Add(Players);
        }



        public void AddlistProperties(CPokemon Pokemon)
        {
            _LPokemon.Add(Pokemon);
        }

        

    }
}
