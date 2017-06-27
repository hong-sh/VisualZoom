using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BoyeoZoom
{
    public class RandomColorGenerator
    {
        private int idx;
        private static List<SolidColorBrush> list;

        static RandomColorGenerator()
        {
            list = new List<SolidColorBrush>();

            list.Add(new SolidColorBrush(Color.FromRgb(170, 255, 1)));
            list.Add(new SolidColorBrush(Color.FromRgb(255, 170, 1)));
            list.Add(new SolidColorBrush(Color.FromRgb(255, 0, 170)));
            list.Add(new SolidColorBrush(Color.FromRgb(170, 0, 255)));
            list.Add(new SolidColorBrush(Color.FromRgb(0, 170, 255)));
        }

        public RandomColorGenerator()
        {
            idx = 0;
        }

        public SolidColorBrush next()
        {
            int index = idx;

            idx = (idx + 1 + list.Count) % list.Count;

            return list[index];
        }

    }
}
