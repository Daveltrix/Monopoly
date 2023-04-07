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
        public static List<CPlayers> Read_Xml(String path_ied)
        {
            List<CPlayers> _ListPlayers = new List<CPlayers>();


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_ied);

            XmlNodeList? playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes)
            {           
                String Name     = playerNode.Attributes["Name"].Value;
                String Id       = playerNode.Attributes["Id"].Value;
                String Money    = playerNode.Attributes["Money"].Value;
                String Figure   = playerNode.Attributes["Figure"].Value;


                CPlayers players = new CPlayers(Name, Convert.ToInt32(Id), Convert.ToInt32(Money), Figure);
                _ListPlayers.Add(players);
            }
            return _ListPlayers;
        }
    }
}
