using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BoyeoZoom
{
    public class Server
    {
        private XmlDocument xmldocument;
        private List<Flow> items;

        public Server(byte[] byteArray, string fileName)
        {
            WebReference.WebService1 service = new WebReference.WebService1();
           
            MemoryStream stream = new MemoryStream(byteArray);

            /* convert stream to string*/
            StreamReader reader = new StreamReader(stream);
            BinaryReader br = new BinaryReader(stream);

            br.BaseStream.Position = 0;
            byte[] binFile = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
            br.Close();

            
            this.xmldocument = new XmlDocument();

            xmldocument.LoadXml(service.PutFile(binFile, fileName).OuterXml);

            Parsing parsing = new Parsing();
            parsing.XmlParsing(xmldocument);

            this.items = parsing.getItems();

            //xmldocument.Save("result.xml");
        }

        public XmlDocument getxmldocument()
        {
            return this.xmldocument;
        }

        public List<Flow> getItems()
        {
            return this.items;
        }
    }
}
