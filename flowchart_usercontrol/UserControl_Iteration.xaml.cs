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
    /// UserControlIteration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_Iteration : UserControl
    {
        private double Top;
        private double Bottom;
        private double Left;
        private double Right;
        private Flow flow;

        public UserControl_Iteration(double left, double top, Flow flow)
        {


            InitializeComponent();

            this.Left = left;
            this.Top = top;
            Right = this.Left + stack_iteration.Width;
            Bottom = this.Top + stack_iteration.Height;
            this.flow = flow;
            textBox_iteration1.Text = flow.Text;
            textBox_iteration2.Text = "";
        }

        public void SetText2(string text)
        {
            textBox_iteration2.Text += text + "\n";
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

