using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Monopoly
{
    public class Game_Loop
    {
        private Int32 _mIndex;
        private Int32 _mToPay;
        private CPlayers? _mTrainer;

        public Game_Loop() {}

        /// <summary>
        /// Funcion que depende de la casilla donde estes realices una funcion
        /// </summary>
        /// <param name="box"></param>
        /// <param name="Player"></param>
        /// <param name="Pokemon"></param>
        /// <param name="_lPlayer"></param>
        /// 

        public void Function_proof(CPlayers Player, Game_SetUp Setup)
        {
            _mIndex = Setup._LBoxes[Player.Box].BoxPoke;
            
            if (Setup._LBoxes[Player.Box].BoxType.Contains("Pokemon"))
            {
                if (Setup._LPokemon[_mIndex].Sold == false) // Si el pokemon esta libre
                {
                    Console.WriteLine($"El pokemon {Setup._LBoxes[Player.Box].NameBox} se encuentra libre. ¿Deseas capturarlo?");
                    String? answer = Console.ReadLine();
                    if (answer!.Contains("y"))
                    {
                        Setup._LPokemon[_mIndex].Trainer = Player.Name;
                        Player.Money = Player.Money - Setup._LPokemon[_mIndex].Value;
                        Setup._LPokemon[_mIndex].Sold = true;
                        Setup._LPokemon[_mIndex].Level++ ;
                        Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Setup._LPokemon[_mIndex].Name}");
                    }
                }

                else if ((Setup._LPokemon[_mIndex].Sold == true) && (Player.Name == Setup._LPokemon[_mIndex].Trainer)) // Si tengo al pokemon
                {
                    Console.WriteLine("Este pokemon ya lo tienes registrado en la pokedex. Sigue tu aventura");
                    Console.WriteLine($"¿Quieres darle un caramelo raro a tu Pokemon {Setup._LPokemon[_mIndex].Name}");
                    String? answer = Console.ReadLine();
                    if (answer!.Contains("y"))
                    {
                        _mToPay = FVariousFunctions.LanzarDado() * Setup._LPokemon[_mIndex].Value;
                        Player.Money = Player.Money - _mToPay;
                        Setup._LPokemon[_mIndex].Level++;
                        Console.WriteLine($"El pokemon {Setup._LPokemon[_mIndex].Name} ha subido de nivel al {Setup._LPokemon[_mIndex].Level.ToString()}");
                        //Setup._LPokemon[_mIndex].Trainer = Player.Name;
                        //Player.Money = Player.Money - Setup._LPokemon[_mIndex].Value;
                        //Setup._LPokemon[Setup._LBoxes[Player.Box].BoxPoke].Sold = true;
                        //Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Setup._LPokemon[_mIndex].Name}");
                    }
                }

                else // No tengo al pokemon y hay que pagar
                {
                    Console.ReadKey();
                    _mTrainer = Setup._LPlayers.Where(x => x.Name == Setup._LPokemon[_mIndex].Trainer).First();
                    Console.WriteLine("El Pokemon pertenece al entrenador: " + Setup._LPokemon[_mIndex].Trainer);
                    Console.WriteLine($"Te has de enfrentar a {Setup._LPokemon[_mIndex].Name} del entrenador: {Setup._LPokemon[_mIndex].Trainer}");

                    _mToPay = FVariousFunctions.LanzarDado() * Setup._LPokemon[_mIndex].Value;
                    Player.Money = Player.Money - _mToPay;
                    _mTrainer.Money = _mTrainer.Money + _mToPay;
                    Console.WriteLine("Tienes que pagar: " + _mToPay.ToString() );
                    Console.WriteLine($"El entrenador {Player.Name} tiene {Player.Money}");
                    Console.WriteLine($"El entrenador del pokemon {_mTrainer.Name} tiene {_mTrainer.Money}");


                }

                
                
            }


            
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
