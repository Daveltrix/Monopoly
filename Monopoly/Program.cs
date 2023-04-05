using System;
using System.Xml;
using FuncLibrary;

namespace MiPrograma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COMIENZA LA PARTIDA MAS DIVERTIDA DE TU VIDA: EL MONOPOLY");

            String path_ied = "Game.ied";
            
            FunctionClass.Read_Xml(path_ied);


            Console.WriteLine("Authors: PASCUAL Y JAIME");
            Console.ReadKey();
        }
    }
}
