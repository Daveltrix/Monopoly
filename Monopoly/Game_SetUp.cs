using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monopoly
{
    /// <summary>
    /// Represents the game setup for Monopoly.
    /// </summary>

    public class Game_SetUp
    {

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Game_SetUp"/> class.
        /// </summary>
        /// <param name="path">The path to the XML file containing the game configuration.</param>
        /// 
        public Game_SetUp(string path)
        {
            _LPlayers = new List<CPlayers>();
            _LPokemon = new List<CPokemon>();
            _LBoxes = new List<CBox>();
            Read_Xml(path);
        }

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Gets or sets the list of players.
        /// </summary>
        /// 
        public List<CPlayers> _LPlayers { get; set; }


        /// <summary>
        /// Gets or sets the list of Pokémon.
        /// </summary>
        /// 
        public List<CPokemon> _LPokemon { get; set; }


        /// <summary>
        /// Gets or sets the list of boxes.
        /// </summary>
        /// 
        public List<CBox> _LBoxes { get; set; }


        #endregion


        #region MEMBERS

        /// <summary>
        /// Represents the index of the current Pokémon.
        /// </summary>

        private int index_pokemon = 0;


        #endregion


        #region METHODS

        /// <summary>
        /// Adds a player to the list of players.
        /// </summary>
        /// <param name="Players">The player to add.</param>

        private void AddlistPlayers(CPlayers Players)
        {
            _LPlayers.Add(Players);
        }

        /// <summary>
        /// Adds a Pokémon to the list of Pokémon.
        /// </summary>
        /// <param name="Pokemon">The Pokémon to add.</param>
 
        private void AddlistPokemons(CPokemon Pokemon)
        {
            _LPokemon.Add(Pokemon);
        }

        /// <summary>
        /// Adds a box to the list of boxes.
        /// </summary>
        /// <param name="Box">The box to add.</param>

        private void AddlistBox(CBox Box)
        {
            _LBoxes.Add(Box);
        }

        #endregion


        #region FUNCTION

        /// <summary>
        /// Reads the XML file containing the game configuration.
        /// </summary>
        /// <param name="path_ied">The path to the XML file.</param>

        public void Read_Xml(string path_ied)
        {
            // Initialize XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_ied);



            // Read player nodes
            XmlNodeList? playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes!)
            {
                string Name = playerNode.Attributes!["Name"]!.Value;
                string Id = playerNode.Attributes!["Id"]!.Value;
                string Money = playerNode.Attributes!["Money"]!.Value;
                string Figure = playerNode.Attributes!["Figure"]!.Value;
                string Turn = playerNode.Attributes!["Turn"]!.Value;
                string Box = playerNode.Attributes!["Box"]!.Value;

                CPlayers players = new CPlayers(Name, Convert.ToInt32(Id), Convert.ToInt32(Money), Figure, Convert.ToBoolean(Turn), Convert.ToInt32(Box));
                AddlistPlayers(players);
            }


            // Read Pokémon nodes
            XmlNodeList? NodePokemon = xmlDoc.SelectNodes("//Pokemon");
            foreach (XmlNode pokemonNode in NodePokemon!)
            {
                string Name = pokemonNode.Attributes!["Name"]!.Value;
                string Value = pokemonNode.Attributes!["Value"]!.Value;
                string Color = pokemonNode.Attributes!["Color"]!.Value;
                string Sold = pokemonNode.Attributes!["Sold"]!.Value;
                string Level = pokemonNode.Attributes!["Level"]!.Value;
                string MaxNum = pokemonNode.Attributes!["MaxNum"]!.Value;

                CPokemon Pokemon = new CPokemon(Name, Convert.ToInt32(Value), Color, Convert.ToBoolean(Sold), Convert.ToInt32(Level), Convert.ToInt32(MaxNum));
               
                AddlistPokemons(Pokemon);
            }



            // Read box nodes
            XmlNodeList? NodeBoxes = xmlDoc.SelectNodes("//Box");
            foreach (XmlNode boxNode in NodeBoxes!)
            {
                string Name = boxNode.Attributes!["Name"]!.Value;
                string Position = boxNode.Attributes!["position"]!.Value;
                string NameBox = boxNode.Attributes!["NameBox"]!.Value;
                string BoxType = boxNode.Attributes!["BoxType"]!.Value;
                string BoxPoke = boxNode.Attributes!["BoxPoke"]!.Value;

                CBox Box = new CBox(Name, Convert.ToInt32(Position), NameBox, BoxType, Convert.ToInt32(BoxPoke));
                AddlistBox(Box);
            }




            // Assign Pokémon names to boxes
            foreach (CBox box in _LBoxes)
            {
                if (string.IsNullOrEmpty(box.NameBox))
                {
                    box.NameBox = _LPokemon[index_pokemon].Name!;
                    index_pokemon++;
                }
            }
        }
        #endregion

    }
}




