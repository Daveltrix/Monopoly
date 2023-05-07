using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monopoly
{
    public class FFuncLibrary
    {
        /// <summary>
        /// Funcion para leer el archivo de configuracion ied.
        /// </summary>
        /// <param name="path_ied"></param> Nombre del archivo .ied
        /// <returns></returns> Se retornan un objeto con listas en funcion del archivo ied
        public static Game_SetUp Read_Xml(String path_ied)
        {
            #region INICIALIZATE
            Game_SetUp SetUp = new Game_SetUp();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_ied);
            #endregion


            #region PLAYERS
            XmlNodeList? playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes!)
            {           
                String Name     =   playerNode.Attributes!["Name"]!.Value;
                String Id       =   playerNode.Attributes!["Id"]!.Value;
                String Money    =   playerNode.Attributes!["Money"]!.Value;
                String Figure   =   playerNode.Attributes!["Figure"]!.Value;
                String Turn     =   playerNode.Attributes!["Turn"]!.Value;
                String Box      =   playerNode.Attributes!["Box"]!.Value;

                CPlayers players = new CPlayers(Name, Convert.ToInt32(Id), Convert.ToInt32(Money), Figure, Convert.ToBoolean(Turn), Convert.ToInt32(Box));
                SetUp.AddlistPlayers(players);
            }
            #endregion


            #region POKEMON
            XmlNodeList? NodePokemon = xmlDoc.SelectNodes("//Pokemon");
            foreach (XmlNode pokemonNode in NodePokemon!)
            {
                String Name     =   pokemonNode.Attributes!["Name"]!.Value;
                String Value    =   pokemonNode.Attributes!["Value"]!.Value;
                String Color    =   pokemonNode.Attributes!["Color"]!.Value;
                String Sold     =   pokemonNode.Attributes!["Sold"]!.Value;
                String Level    =   pokemonNode.Attributes!["Level"]!.Value;
                String MaxNum   =   pokemonNode.Attributes!["MaxNum"]!.Value;

                CPokemon Pokemon = new CPokemon (Name, Convert.ToInt32(Value), Color, Convert.ToBoolean(Sold), Convert.ToInt32(Level), Convert.ToInt32(MaxNum));
                SetUp.AddlistPokemons(Pokemon);
            }
            #endregion


            #region BOXES
            XmlNodeList? NodeBoxes = xmlDoc.SelectNodes("//Box");
            foreach (XmlNode boxNode in NodeBoxes!)
            {
                String Name = boxNode.Attributes!["Name"]!.Value;
                String Position = boxNode.Attributes!["position"]!.Value;
                String NameBox = boxNode.Attributes!["NameBox"]!.Value;
                String BoxType = boxNode.Attributes!["BoxType"]!.Value;
                String BoxPoke = boxNode.Attributes!["BoxPoke"]!.Value;

                CBox Box = new CBox(Name, Convert.ToInt32(Position), NameBox, BoxType, Convert.ToInt32(BoxPoke));
                SetUp.AddlistBox(Box);
            }
            #endregion


            Int32 index_pokemon = 0;

            foreach (CBox box in SetUp._LBoxes)
            {
                if (String.IsNullOrEmpty(box.NameBox)) 
                {
                    box.NameBox = SetUp._LPokemon[index_pokemon].Name!;
                    index_pokemon++;
                }
            }


            return SetUp;
        }
    }
}
