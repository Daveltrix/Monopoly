using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FuncLibrary
{
    public class FunctionClass
    {
        public static void Read_Xml(String path_ied)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_ied);

            XmlNodeList playerNodes = xmlDoc.SelectNodes("//player");
            foreach (XmlNode playerNode in playerNodes)
            {
                String nombre = playerNode.Attributes["name"].Value;
                String id = playerNode.Attributes["id"].Value;
                String dinero = playerNode.Attributes["dinero"].Value;
                String figura = playerNode.Attributes["figura"].Value;

                Console.WriteLine($"nombre={nombre} id={id} dinero={dinero} figura={figura}");
            }
        }
    }
}
