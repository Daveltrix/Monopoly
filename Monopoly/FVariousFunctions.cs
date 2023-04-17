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



        /// <summary>
        /// Funcion que simula el lanzamiento de un dado
        /// </summary>
        /// <returns></returns>
        public static Int32 LanzarDado()
        {
            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, 7);
            return RandomNumber;
        }

        /// <summary>
        /// Muestra por consola los comandos que hay
        /// </summary>
        public static void ShowCommandsConsole()
        {
            Console.WriteLine("Opcion1: Estado");
            Console.WriteLine("Opcion2: Pokemons");
            Console.WriteLine("Opcion1: Continue");
        }
    }
}
