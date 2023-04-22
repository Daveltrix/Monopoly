using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game_Loop
    {
        public Game_Loop() { }

        /// <summary>
        /// Funcion que depende de la casilla donde estes realices una funcion
        /// </summary>
        /// <param name="box"></param>
        /// <param name="Player"></param>
        /// <param name="Pokemon"></param>
        /// <param name="_lPlayer"></param>
        public static void Function_Loop(Int32 box, CPlayers Player, List<CPokemon> Pokemon, List<CPlayers> _lPlayer)
        {
            Int32 ToPay = 0;
            Int32 Indexlist;
            CPlayers Trainer;
            
            
            switch (box)
            {
                case 0:
                    Console.WriteLine("Se encuentra en la casilla 0");
                    break;
                case 1:
                    Indexlist = 0;
                    if (Pokemon[Indexlist].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[Indexlist].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y")) 
                        {
                            Pokemon[Indexlist].Trainer = Player.Name;
                            Player.Money = Player.Money - Pokemon[Indexlist].Value;
                            Pokemon[Indexlist].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[Indexlist].Name}");
                        }               
                    }
                    else if ((Pokemon[Indexlist].Sold == true) && (Player.Name == Pokemon[Indexlist].Trainer))
                    {
                        Console.WriteLine("Este pokemon ya lo tienes registrado en la pokedex. Sigue tu aventura");
                    }
                    else
                    {
                        Console.ReadKey();
                        Trainer = _lPlayer.Where(x => x.Name == Pokemon[Indexlist].Trainer).First();
                        Console.WriteLine("El Pokemon pertenece al entrenador: " + Pokemon[Indexlist].Trainer);
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[Indexlist].Name} del entrenador: {Pokemon[Indexlist].Trainer}" );
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[Indexlist].Value;
                        Player.Money = Player.Money - ToPay;
                        Trainer.Money = Trainer.Money + ToPay;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());
                        Console.WriteLine($"El entrenador {Player.Name} tiene {Player.Money}");
                        Console.WriteLine($"El entrenador del pokemon {Trainer.Name} tiene {Trainer.Money}");

                    }
                    break;
                case 2:
                    Indexlist = 1;
                    if (Pokemon[Indexlist].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[Indexlist].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Pokemon[Indexlist].Trainer = Player.Name;
                            Player.Money = Player.Money - Pokemon[Indexlist].Value;
                            Pokemon[Indexlist].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[Indexlist].Name}");
                        }
                    }
                    else if ((Pokemon[Indexlist].Sold == true) && (Player.Name == Pokemon[Indexlist].Trainer))
                    {
                        Console.WriteLine("Este pokemon ya lo tienes registrado en la pokedex. Sigue tu aventura");
                    }
                    else
                    {
                        Console.ReadKey();
                        Trainer = _lPlayer.Where(x => x.Name == Pokemon[Indexlist].Trainer).First();
                        Console.WriteLine("El Pokemon pertenece al entrenador: " + Pokemon[Indexlist].Trainer);
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[Indexlist].Name} del entrenador: {Pokemon[Indexlist].Trainer}");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[Indexlist].Value;
                        Player.Money = Player.Money - ToPay;
                        Trainer.Money = Trainer.Money + ToPay;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());
                        Console.WriteLine($"El entrenador {Player.Name} tiene {Player.Money}");
                        Console.WriteLine($"El entrenador del pokemon {Trainer.Name} tiene {Trainer.Money}");

                    }
                    break;
                case 3:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 4:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 5:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 6:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 7:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 8:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 9:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }
                    break;
                case 10:
                    if (Pokemon[box].Sold == false)
                    {
                        Console.WriteLine($"Pokemon {Pokemon[box].Name} salvaja ha aparecido. ¿Desea capturarlo?");
                        string answer = Console.ReadLine();
                        if (answer.Contains("y"))
                        {
                            Player.Money = Player.Money - Pokemon[box].Value;
                            Pokemon[box].Sold = true;
                            Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Pokemon[box].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Te has de enfrentar a {Pokemon[box].Name}. Tira el dado ");
                        ToPay = FVariousFunctions.LanzarDado() * Pokemon[box].Value;
                        Console.WriteLine("Tienes que pagar: " + ToPay.ToString());

                    }

                    break;
            }
            Console.WriteLine($"El jugador {Player.Name} tiene un total de {Player.Money} Pokemonedas");
        }


        /// <summary>
        /// Funcion para desplegar el menu en la consola
        /// </summary>
        /// <param name="comand"></param>
        /// <param name="Setup"></param>
        /// <returns></returns>
        public static Int32 State_Game(String comand, Game_SetUp Setup)
        {
            Int32 num_return = 0;

            switch(comand)
            {
                case "Estado":
                    foreach(CPlayers Player in Setup._LPlayers)
                    {
                        Console.WriteLine($"El jugador {Player.Name} tiene {Player.Money} Pokemonedas.");
                    }
                    break;
                case "Pokemons":
                    foreach (CPokemon Pokemon in Setup._LPokemon)
                    {
                        if (Pokemon.Sold == false)
                        {
                            Console.WriteLine($"El Pokemon {Pokemon.Name} se encuentra libre.");
                        }
                        else if (Pokemon.Sold == true)
                        {
                            Console.WriteLine($"El Pokemon {Pokemon.Name} esta capturado.");
                        }
                        
                    }
                    break;
            }

            return num_return;
        }

    }
}
