using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private String? _mAnswer;
        private Int32 _mlevel;
        private Int32 _mlevellist;


        public Game_Loop() {}


        /// <summary>
        /// Executes a specific action depending on the current game box where the player is located.
        /// </summary>
        /// <param name="Player">The player instance.</param>
        /// <param name="Setup">The game setup instance.</param>
        
        public void CatchPokemon(CPlayers Player, Game_SetUp Setup)
        {
            _mIndex = Setup._LBoxes[Player.Box].BoxPoke;
            _mlevel = Setup._LPokemon[_mIndex].Level;
            _mlevellist = _mlevel - 1;


            if (Setup._LBoxes[Player.Box].BoxType.Contains("Pokemon"))
            {
                if (Setup._LPokemon[_mIndex].Sold == false) // Si el pokemon esta libre
                {
                    _mToPay = FVariousFunctions.LanzarDado() * Setup._LPokemon[_mIndex].Attacks![_mlevellist].Power;
                    Console.WriteLine($"El pokemon {Setup._LBoxes[Player.Box].NameBox} se encuentra libre. ¿Deseas capturarlo?");
                    Console.WriteLine($"Te saldria por {_mToPay} Pokemonedas");
                    _mAnswer = Console.ReadLine();
                    if (_mAnswer!.Contains("y"))
                    {
                        Setup._LPokemon[_mIndex].Trainer = Player.Name;
                        Player.Money = Player.Money - _mToPay;
                        Setup._LPokemon[_mIndex].Sold = true;
                        Setup._LPokemon[_mIndex].Level++ ;
                        Console.WriteLine($"El jugador {Player.Name} ha capturado el Pokemon salvaje: {Setup._LPokemon[_mIndex].Name}");
                    }
                }

                else if ((Setup._LPokemon[_mIndex].Sold == true) && (Player.Name == Setup._LPokemon[_mIndex].Trainer)) // Si tengo al pokemon
                {
                    Console.WriteLine($"Ya tienes registrado a {Setup._LPokemon[_mIndex].Name} en la pokedex. Sigue tu aventura");
                    
                    if (_mlevel == Setup._LPokemon[_mIndex].Attacks!.Count())
                    {
                        Console.WriteLine($"El pokemon {Setup._LPokemon[_mIndex].Name} ya ha alcanzado el maximo nivel");
                    }
                    else
                    {
                        _mToPay = FVariousFunctions.LanzarDado() * Setup._LPokemon[_mIndex].Attacks![_mlevellist].Power;
                        Console.WriteLine($"¿Quieres darle un caramelo raro a tu Pokemon {Setup._LPokemon[_mIndex].Name}. Te saldria por {_mToPay.ToString()} Pokemonedas");
                        _mAnswer = Console.ReadLine();
                        if (_mAnswer!.Contains("y"))
                        {
                            
                            Player.Money = Player.Money - _mToPay;
                            Setup._LPokemon[_mIndex].Level++;
                            Console.WriteLine($"El pokemon {Setup._LPokemon[_mIndex].Name} ha subido de nivel al {Setup._LPokemon[_mIndex].Level.ToString()}");
                        }
                    }
                    
                }

                else // No tengo al pokemon y hay que pagar
                {
                    Console.ReadKey();
                    _mTrainer = Setup._LPlayers.Where(x => x.Name == Setup._LPokemon[_mIndex].Trainer).First();
                    Console.WriteLine("El Pokemon pertenece al entrenador: " + Setup._LPokemon[_mIndex].Trainer);
                    Console.WriteLine($"Te has de enfrentar a {Setup._LPokemon[_mIndex].Name} del entrenador: {Setup._LPokemon[_mIndex].Trainer}");

                    _mToPay = FVariousFunctions.LanzarDado() * Setup._LPokemon[_mIndex].Attacks![_mlevellist].Power;

                    Player.Money = Player.Money - _mToPay;
                    _mTrainer.Money = _mTrainer.Money + _mToPay;
                    Console.WriteLine("Tienes que pagar: " + _mToPay.ToString());
                    Console.WriteLine($"El entrenador {Player.Name} tiene {Player.Money}");
                    Console.WriteLine($"El entrenador del pokemon {_mTrainer.Name} tiene {_mTrainer.Money}");
                    
                    
                }
            }
        }

        /// <summary>
        /// Retrieves and displays the current state of the game based on the specified command.
        /// </summary>
        /// <param name="comand">Specific command of the game.</param>
        /// <param name="Setup">Instance of the Game_SetUp class containing game data.</param>
        /// <returns>The resulting integer value.</returns>

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
