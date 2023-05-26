using System;
using System.Xml;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COMIENZA LA PARTIDA MAS DIVERTIDA DE TU VIDA: EL MONOPOLY");
            Console.WriteLine("");

            #region CARGAR PARAMETROS

            // Paht
            String path_ied = "Game.ied";

            // Para guardar las listas
            Game_SetUp Setup = new Game_SetUp(path_ied);

            // Para comenzar el juego
            Game_Loop _Game_Loop = new Game_Loop();

            CPlayers Player = new CPlayers();

            #endregion
            Int32 TotalBox = Setup._LBoxes.Count;
            Int32 Dice;



            while (true)
            {
                //foreach (CPlayers Player in Setup._LPlayers)
                for (Int32 i = 0; i < Setup._LPlayers.Count; i++)
                {
                    Player = Setup._LPlayers[i];
                    Console.WriteLine("==============================================================");

                    // Lanzamiento del dado
                    Dice = FVariousFunctions.LanzarDado();
                    

                    // Casillas especiales
                    if (((Player.Box == 3) || (Player.Box == 4) || (Player.Box == 5)) && Player.Turn == true)
                    {
                        Player.Turn = false;
                        Console.WriteLine($"Ha caido en la carcel. El jugador {Player.Id} --> " +
                            $"{Player.Name} se encuentra en la carcel: {Player.Box}.");
                    }

                    // Pokemon
                    else
                    {
                        Player.Turn = true;
                        Player.Box = Player.Box + Dice;

                        // ¿Le hemos dado la vuelta al tablero?
                        if (Player.Box >= TotalBox)
                        {
                            Player.Box = Player.Box - TotalBox;
                            Player.Money = Player.Money + 1;
                        }


                        Console.WriteLine($"Ha salido un: {Dice.ToString()}. El jugador {Player.Id} -->" +
                            $" {Player.Name} se encuentra en la casilla: {Player.Box}.");


                        _Game_Loop.CatchPokemon(Player, Setup);

                        Player.Turn = true;



                        if (Player.Money <= 0)
                        {
                            Setup = FVariousFunctions.DeletePlayer(Setup);
                            i = i - 1;
                        }




                        Console.WriteLine("==============================================================");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    
                }


                // Finish game
                if (Setup._LPlayers.Count == 1)
                {
                    break;
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





            Console.WriteLine($"Felicidades a {Setup._LPlayers[0].Name} por ganar la liga pokemon");
            Console.WriteLine("Authors: PASCUAL Y JAIME");
            Console.ReadKey();
        }
    }
}
