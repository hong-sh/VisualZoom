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
    /// UserControl_arrayItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_variableItem : UserControl
    {
        public C_DATA Data { get; set; }

        public UserControl_variableItem(C_DATA data)
        {
            InitializeComponent();
            Data = data;
        }

        public void setText(string txt)
        {
            val.Text = txt;
        }

        public string getText()
        {
            return val.Text;
        }

        public void setBackgroundNULL()
        {
            val.Text = "     ";

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"../../image/null_pointer.png", UriKind.Relative));
            ib.Stretch = Stretch.None;
            val.Background = ib;
        }
    }
}
