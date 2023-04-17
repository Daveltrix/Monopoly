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

            Int32 TotalBox = 3;
            String ReadConsole;
            String Command;




            while(true)
            {
                foreach(CPlayers Player in Setup._LClayers)
                {
                    Console.WriteLine("======================================================");
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
                        if (Player.Box >= TotalBox)
                        {
                            Player.Box = 0 + Player.Box - TotalBox;
                            Player.Money = Player.Money + 100;
                        }
                        Console.WriteLine($"Ha salido un: {Dice.ToString()}. El jugador {Player.Id} -->" +
                            $" {Player.Name} se encuentra en la casilla: {Player.Box}.");
                        Console.WriteLine("======================================================");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                Console.Write("¿Desea ver la partida?");
                ReadConsole = Console.ReadLine();
                if (ReadConsole.Contains("y"))
                {
                    while(true)
                    {
                        Console.WriteLine("Introuduzca el comando");
                        FVariousFunctions.ShowCommandsConsole();
                        ReadConsole = Console.ReadLine();
                        if (ReadConsole.Contains("Continue"))
                        {
                            break;
                        }
                        else
                        {

                        }
                        
                    }
                    break;
                }
            }
            
            




            Console.WriteLine("Authors: PASCUAL Y JAIME");
            Console.ReadKey();
        }
    }
}
