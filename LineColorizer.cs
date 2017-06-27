using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Document;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Rendering;

namespace BoyeoZoom
{
    public class LineColorizer : ICSharpCode.AvalonEdit.Rendering.DocumentColorizingTransformer
    {
        int lineNumber;

        public LineColorizer(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        protected override void ColorizeLine(DocumentLine line)
        {
            if (!line.IsDeleted && line.LineNumber == lineNumber)
            {
                ChangeLinePart(line.Offset, line.EndOffset, ApplyChanges);
            }
            else if(!line.IsDeleted && line.LineNumber != lineNumber) {
                ChangeLinePart(line.Offset, line.EndOffset, ApplyChanges2);
            }
        }

        void ApplyChanges(VisualLineElement element)
        {
            // This is where you do anything with the line
            //element.TextRunProperties.SetForegroundBrush(Brushes.Red);
            element.TextRunProperties.SetBackgroundBrush(Brushes.DarkOrange);
            //element.TextRunProperties.SetBackgroundBrush(Brushes.Transparent);
        }

        void ApplyChanges2(VisualLineElement element) {
            element.TextRunProperties.SetBackgroundBrush(Brushes.Transparent);
        }
    }



}
