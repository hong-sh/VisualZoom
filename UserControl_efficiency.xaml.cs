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
    /// UserControl_efficiency.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_efficiency : UserControl
    {
        public UserControl_efficiency()
        {
            InitializeComponent();
        }

        private void text_excute_Loaded(object sender, RoutedEventArgs e)
        {
            text_excute.Text = "";
            text_memory.Text = "";
        }
    }
}
