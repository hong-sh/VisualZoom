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

namespace BoyeoZoom
{
    /// <summary>
    /// UserControl_funcPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_funcPanel : UserControl
    {
        public UserControl_funcPanel()
        {
            InitializeComponent();
        }

        public void Add(UserControl_variable uc)
        {
            funcPanel.Children.Add(uc);

            makeBeauty();
        }

        public void setLabel(string txt)
        {
            funcLabel.Content = txt;
        }

        public UIElementCollection getPanelChildren()
        {
            return funcPanel.Children;
        }

        private void makeBeauty()
        {

            double maxWidth = 100f;
            foreach(UserControl_variable uv in funcPanel.Children)
            {
                Label variable_name = uv.v2_name;
                variable_name.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                double tmpWidth = variable_name.DesiredSize.Width;
                maxWidth = (tmpWidth > maxWidth) ? tmpWidth : maxWidth;
            }

            foreach(UserControl_variable uv in funcPanel.Children)
            {
                uv.v2_name.Width = maxWidth;
            }
        }
    }
}
