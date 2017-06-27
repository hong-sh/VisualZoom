using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoyeoZoom.flowchart_usercontrol
{
    /// <summary>
    /// UserControl_arrowB.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_arrowB : UserControl
    {
        private int StartLine;
        private double Bottom;
        private double Top;

        public UserControl_arrowB(double Top, int StartLine)
        {
            InitializeComponent();
            this.StartLine = StartLine;
            this.Top = Top;
            this.Bottom = Top + image_Bgray.Height;
        }

        public double GetTop()
        {
            return this.Top;
        }
        public double GetBottom()
        {
            return this.Bottom;
        }

        public int GetStartLine()
        {
            return this.StartLine;
        }

        public void SetBackground(int flag)
        {
            if (flag == 0)
            {
                image_Bgray.Source = new BitmapImage(new Uri("/image/down_gray.png", UriKind.RelativeOrAbsolute));
            }
            else if (flag == 1)
            {
                image_Bgray.Source = new BitmapImage(new Uri("/image/down_red.png", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
