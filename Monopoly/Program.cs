using System;
using System.Xml;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COMIENZA LA PARTIDA MAS DIVERTIDA DE TU VIDA: EL MONOPOLY");

            #region CARGAR PARAMETROS
            String path_ied = "Game.ied";
            CSetUp Setup = new CSetUp();
            Setup = CFuncLibrary.Read_Xml(path_ied);
            #endregion

            Int32 prueba = 0;
            Int32 dado = 0;
            //while(true)
            //{
            //    dado = FVariousFunctions.LanzarDado();
            //    prueba = prueba + dado;
                

            //    if (prueba >= 39)
            //    {
            //        prueba = 0 + prueba - 39;
            //    }
            //    Console.WriteLine(dado.ToString() +"       "+prueba.ToString());
            //    string salir = Console.ReadLine();
            //    if (salir.Contains("a"))
            //    {
            //        break;
            //    }
            //}




            while(true)
            {
                foreach(CPlayers Player in Setup._LClayers)
                {
                    Int32 Dice = FVariousFunctions.LanzarDado();
                    if (((Player.Box == 4) || (Player.Box == 5) || (Player.Box == 6)) && Player.Turn == true)
                    {
                        Player.Turn = false;
                        Console.WriteLine($"Ha caido en la carcel. El jugador {Player.Id} --> " +
                            $"{Player.Name} se encuentra en la carcel: {Player.Box}.");
                    }
                    else
                    {
                        Player.Turn = true;
                        Player.Box = Player.Box + Dice;
                        if (Player.Box >= 39)
                        {
                            Player.Box = 0 + Player.Box - 39;
                            Player.Money = Player.Money + 100;
                        }
                        Console.WriteLine($"Ha salido un: {Dice.ToString()}. El jugador {Player.Id} -->" +
                            $" {Player.Name} se encuentra en la casilla: {Player.Box}.");
                    }
                    Console.ReadKey();
                }

                string salir = Console.ReadLine();
                if (salir.Contains("a"))
                {
                    break;
                }
            }
            
            




            Console.WriteLine("Authors: PASCUAL Y JAIME");
            Console.ReadKey();
        }
    }
}
