using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CPlayers
    {
        public String Name { get; set; } = string.Empty;
        public Int32 Id { get; set; }
        public Int32 Money { get; set; }
        public String Figure { get; set; } = string.Empty;
        public Boolean Turn { get; set; }
        public Int32 Box { get; set; }



        public CPlayers() { }

        public CPlayers(String Name, Int32 Id, Int32 Money, String Figure, Boolean Turn, Int32 Box) 
        {
            this.Name= Name;
            this.Id= Id;
            this.Money = Money;
            this.Figure = Figure;
            this.Turn = Turn;
            this.Box = Box;
        }
    }
}
