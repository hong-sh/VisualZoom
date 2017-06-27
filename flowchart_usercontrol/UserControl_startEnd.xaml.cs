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
    /// UserControl_rectangle.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_startEnd : UserControl
    {

        private double Top;
        private double Bottom;
        private double Left;
        private double Right;
        private Flow flow;

        public UserControl_startEnd(double left, double top, Flow flow)
        {
            InitializeComponent();

            this.Left = left;
            this.Top = top;
            Right = this.Left + textBox_startEnd.Width;
            Bottom = this.Top + textBox_startEnd.Height;
            this.flow = flow;
            textBox_startEnd.Text = flow.Text;
        }



        public double GetTop()
        {
            return this.Top;
        }
        public void SetTop(double top)
        {
            this.Top = top;
        }

        public double GetBottom()
        {
            return this.Bottom;
        }
        public void SetBottom(double bottom)
        {
            this.Bottom = bottom;
        }

        public double GetLeft()
        {
            return this.Left;
        }
        public void SetLeft(double left)
        {
            this.Left = left;
        }

        public double GetRight()
        {
            return this.Right;
        }
        public void SetRight(double right)
        {
            this.Right = right;
        }
    }
}
