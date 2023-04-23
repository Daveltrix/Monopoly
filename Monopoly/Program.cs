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
            Game_SetUp Setup = new Game_SetUp();
            Game_Loop _Game_Loop = new Game_Loop();
            Setup = FFuncLibrary.Read_Xml(path_ied);
            #endregion
            Int32 TotalBox = 3;
            String? consola;
            String? comando;

            
            while(true)
            {
                foreach(CPlayers Player in Setup._LPlayers)
                {
                    Console.WriteLine("==============================================================");
                    Int32 Dice = FVariousFunctions.LanzarDado();
                    if (((Player.Box == 15) || (Player.Box == 16) || (Player.Box == 17)) && Player.Turn == true)
                    {
                        Player.Turn = false;
                        Console.WriteLine($"Ha caido en la carcel. El jugador {Player.Id} --> " +
                            $"{Player.Name} se encuentra en la carcel: {Player.Box}.");
                    }
                    else
                    {
                        Player.Turn = true;
                        Player.Box = Player.Box + Dice;
                        if (Player.Box >= TotalBox)
                        {
                            Player.Box = Player.Box - TotalBox;
                            Player.Money = Player.Money + 100;
                        }
                        Console.WriteLine($"Ha salido un: {Dice.ToString()}. El jugador {Player.Id} -->" +
                            $" {Player.Name} se encuentra en la casilla: {Player.Box}.");

                        
                        _Game_Loop.Function_proof(Player, Setup);
                        Console.WriteLine("==============================================================");
                        Console.WriteLine();
                        Console.WriteLine();
                        
                    }
                }
                //Console.WriteLine("¿Desea ver estado de la partida?");
                //consola = Console.ReadLine();
                //if (consola!.Contains("y"))
                //{
                //    while(true)
                //    {
                //        Console.WriteLine("Introduce comando");
                //        FVariousFunctions.ShowCommandsConsole();
                //        comando = Console.ReadLine();
                //        if (comando!.Contains("continue"))
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            Game_Loop.State_Game(comando, Setup);
                //        }
                        
                //    }  
                //}

            }
            
            




            //Console.WriteLine("Authors: PASCUAL Y JAIME");
            //Console.ReadKey();
        }
    }
}
