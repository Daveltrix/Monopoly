﻿using System;
using System.Xml;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COMIENZA LA PARTIDA MAS DIVERTIDA DE TU VIDA: EL MONOPOLY");

            String path_ied = "Game.ied";

            List<CPlayers> _ListPlayers = new List<CPlayers>();


            _ListPlayers = CFuncLibrary.Read_Xml(path_ied);
            


            Console.WriteLine("Authors: PASCUAL Y JAIME");
            Console.ReadKey();
        }
    }
}
