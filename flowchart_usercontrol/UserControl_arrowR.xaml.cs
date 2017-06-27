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
    /// UserControl_arrowR.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class UserControl_arrowR : UserControl
    {
        int StartLine;
        public UserControl_arrowR(int StartLine)
        {
            this.StartLine = StartLine;
            InitializeComponent();
        }

        public int GetStartLine()
        {
            return this.StartLine;
        }
    }
}
