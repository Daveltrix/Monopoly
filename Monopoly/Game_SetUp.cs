using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game_SetUp
    {  
        public Game_SetUp() 
        {
            _LPlayers = new List<CPlayers>();
            _LPokemon = new List<CPokemon>();
            _LBoxes = new List<CBox>();
        }

        public List<CPlayers> _LPlayers { get; set; }
        public List<CPokemon> _LPokemon { get;  set; }
        public List<CBox> _LBoxes { get; set; }




        public void AddlistPlayers(CPlayers Players)
        {
            _LPlayers.Add(Players);
        }



        public void AddlistPokemons(CPokemon Pokemon)
        {
            _LPokemon.Add(Pokemon);
        }

        public void AddlistBox(CBox Box)
        {
            _LBoxes.Add(Box);
        }

    }
}
