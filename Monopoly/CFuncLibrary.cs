using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monopoly
{
    public class CFuncLibrary
    {
        /// <summary>
        /// Reads an XML file and extracts relevant information from it.
        /// </summary>
        /// <param name="path_ied">Path of the .ied file</param>
        /// <returns>CSetUp object with the extracted lists from the XML file</returns>
        /// 
        public CSetUp Read_Xml(String path_ied)
        {
            #region INICIALIZATE

            // Creates a new instance of the CSetUp class called SetUp.
            CSetUp SetUp = new CSetUp();

            // Creates a new instance of the XmlDocument class called xmlDoc.
            XmlDocument xmlDoc = new XmlDocument();

            // Loads the XML file specified by the path_ied parameter into the xmlDoc object using the Load method.
            xmlDoc.Load(path_ied);

            #endregion



            #region PLAYERS

            // Extract "player" nodes from the XML file
            XmlNodeList? playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes)
            {
                // Extract attributes from the player node
                String Name     =   playerNode.Attributes["Name"].Value;
                String Id       =   playerNode.Attributes["Id"].Value;
                String Money    =   playerNode.Attributes["Money"].Value;
                String Figure   =   playerNode.Attributes["Figure"].Value;
                String Turn     =   playerNode.Attributes["Turn"].Value;
                String Box      =   playerNode.Attributes["Box"].Value;

                // Create a CPlayers object with the extracted values and add it to the list in SetUp
                CPlayers players = new CPlayers(Name, Convert.ToInt32(Id), Convert.ToInt32(Money), Figure, Convert.ToBoolean(Turn), Convert.ToInt32(Box));
                SetUp.AddlistPlayers(players);
            }

            #endregion


            #region POKEMON

            // Extract "Pokemon" nodes from the XML file
            XmlNodeList? NodePokemon = xmlDoc.SelectNodes("//Pokemon");
            foreach (XmlNode pokemonNode in NodePokemon)
            {
                // Extract attributes from the Pokemon node
                String Name     =   pokemonNode.Attributes["Name"].Value;
                String Value    =   pokemonNode.Attributes["Value"].Value;
                String Color    =   pokemonNode.Attributes["Color"].Value;
                String Sold     =   pokemonNode.Attributes["Sold"].Value;

                // Create a CPokemon object with the extracted values and add it to the list in SetUp
                CPokemon Pokemon = new CPokemon (Name, Convert.ToInt32(Value), Color, Convert.ToBoolean(Sold));
                SetUp.AddlistProperties(Pokemon);
            }
            #endregion


            return SetUp;
        }
    }
}
