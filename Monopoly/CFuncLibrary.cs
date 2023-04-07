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
        public static CSetUp Read_Xml(String path_ied)
        {
            CSetUp SetUp= new CSetUp();


            XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path_ied);

            XmlNodeList? playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes)
            {           
                String Name     = playerNode.Attributes["Name"].Value;
                String Id       = playerNode.Attributes["Id"].Value;
                String Money    = playerNode.Attributes["Money"].Value;
                String Figure   = playerNode.Attributes["Figure"].Value;
                String Turn     = playerNode.Attributes["Turn"].Value;
                String Box = playerNode.Attributes["Box"].Value;

                CPlayers players = new CPlayers(Name, Convert.ToInt32(Id), Convert.ToInt32(Money), Figure, Convert.ToBoolean(Turn), Convert.ToInt32(Box));
                SetUp.AddlistPlayers(players);
            }



            XmlNodeList? Node_Property = xmlDoc.SelectNodes("//Property");
            foreach (XmlNode propertyNode in Node_Property)
            {
                String Name = propertyNode.Attributes["Name"].Value;
                String Value = propertyNode.Attributes["Value"].Value;
                String Color = propertyNode.Attributes["Color"].Value;
                String Sold = propertyNode.Attributes["Sold"].Value;

                CProperties property = new CProperties (Name, Convert.ToInt32(Value), Color, Convert.ToBoolean(Sold));
                SetUp.AddlistProperties(property);
            }


            return SetUp;
        }
    }
}
