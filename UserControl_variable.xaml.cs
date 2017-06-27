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
    /// UserControl_array.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_variable : UserControl
    {
        public List<C_DATA> ArrList { get; set; }

        public UserControl_variable()
        {
            InitializeComponent();
        }

        public void setName(string name)
        {
            v2_name.Content = name;
        }

        public void AddValues(List<C_DATA> list, Dictionary<string, UserControl_variableItem> dict)
        {
            v2_values.Children.Clear();
            if (list.Count > 0)
            {
                if (list[0].Type == "pointer")
                    highlight.Visibility = Visibility.Visible;
                else
                    highlight.Visibility = Visibility.Hidden;

                ArrList = list;

                foreach (C_DATA val in list)
                {
                    UserControl_variableItem ai = new UserControl_variableItem(val);
                    string txt = val.Value;
                    txt = StringFunc.toBeauty(txt, ai.Data.Type == "char");

                    ai.setText(txt);
                    v2_values.Children.Add(ai);
                    dict.Add(val.Address, ai);
                }
            }
            
        }

        public List<C_DATA> getArrayChildren()
        {
            return ArrList;
        }

        public UIElementCollection getPanelChildren()
        {
            return v2_values.Children;
        }
    }
}
