using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    /// <summary>
    /// Provides various utility functions for Monopoly.
    /// </summary>

    public class FVariousFunctions
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="FVariousFunctions"/> class.
        /// </summary>

        public FVariousFunctions() { }

        #endregion


        #region FUNCTIONS

        /// <summary>
        /// Simulates rolling a die.
        /// </summary>
        /// <returns>The result of the die roll.</returns>

        public static int LanzarDado()
        {
            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, 7);
            return RandomNumber;
            //return 1;
        }

        /// <summary>
        /// Displays the available commands on the console.
        /// </summary>
        
        public static void ShowCommandsConsole()
        {
            Console.WriteLine("Opcion1: Estado");
            Console.WriteLine("Opcion2: Pokemons");
            Console.WriteLine("Opcion3: Continue");
        }


        public static Game_SetUp DeletePlayer(Game_SetUp Setup)
        {
            for (int i = 0; i < Setup._LPlayers.Count; i++)
            {
                if (Setup._LPlayers[i].Money <= 0)
                {
                    Console.WriteLine($"El jugador {Setup._LPlayers[i].Name} ha sido eliminado");
                    Setup._LPlayers.RemoveAt(i);                    
                }
            }
            return Setup;
        }
        #endregion
    }
}
