using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoyeoZoom
{
    public class Flow
    {
        public string Type;
        public int StartLine;
        public int StopLine;
        public string Text;
        public List<Flow> flows;

        public Flow(string Type, int StartLine, int StopLine, string Text)
        {
            this.Type = Type;
            this.StartLine = StartLine;
            this.StopLine = StopLine;
            this.Text = Text;
            this.flows = new List<Flow>();
        }

        public string GetType() {
            return this.Type;
        }

        public int GetStartLine() {
            return this.StartLine;
        }

        public int GetStopLine() {
            return this.StopLine;
        }

        public string GetText() {
            return this.Text;
        }

        public List<Flow> getList() {
            return this.flows;
        }
        
    }
}
