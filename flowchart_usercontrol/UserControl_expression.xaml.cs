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
    /// UserControl_expression.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_expression : UserControl
    {
        private Flow flow;

        private double Left;
        private double Right;
        private double Top;
        private double Bottom;

        public UserControl_expression(double left, double top, Flow flow)
        {

            InitializeComponent();

            this.Left = left;
            this.Top = top;
            Right = this.Left + textBox_expression.Width;
            Bottom = this.Top + textBox_expression.Height;

            this.flow = flow;
            textBox_expression.Text = flow.Text;
        }

        public void setText(string text)
        {
            textBox_expression.Text = text;
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
