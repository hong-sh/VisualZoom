using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BoyeoZoom
{
    public class Parsing
    {
        private List<Flow> flows;

        public Parsing()
        {
            flows = new List<Flow>();
        }

        public void XmlParsing(XmlDocument xml)
        {

            XmlNodeList xnList = xml.GetElementsByTagName("Flow");

            foreach (XmlNode node in xnList)
            {

                string Type = node["Type"].InnerText;
                int StartLine = Int32.Parse(node["StartLine"].InnerText);
                int StopLine = Int32.Parse(node["StopLine"].InnerText);
                string Text = node["Text"].InnerText;

                Flow flow = new Flow(Type, StartLine, StopLine, Text);
                AddList(this.flows, flow);
            }
        }

        private void AddList(List<Flow> flows, Flow flow)
        {

            for (int i = 0; i < flows.Count; i++)
            {
                if (flows[i].GetStartLine() <= flow.GetStartLine() &&
                    flows[i].GetStopLine() >= flow.GetStopLine())
                {
                    if (flow.GetType().Equals("Selection:Else")
                        && flows[i].GetType().Equals("Selection:IF"))
                    {
                        flows[i].StopLine = flow.StartLine;
                        flows.Add(flow);
                        return;
                    }
                    AddList(flows[i].getList(), flow);
                    return;
                }
            }

            flows.Add(flow);

        }

        public List<Flow> getItems()
        {
            return flows;
        }

    }

}
