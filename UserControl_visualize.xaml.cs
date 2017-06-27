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
    /// UserControl_visualize.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_visualize : UserControl
    {
            
        Parsing parsing = new Parsing();

        public UserControl_visualize()
        {
            InitializeComponent();
        }

        public void init()
        {
            myVariable.Children.Clear();
            myHeap.Children.Clear();
        }

        public void Draw_All(Trace step)
        {
            init();

            Dictionary<string, UserControl_variableItem> dict = new Dictionary<string, UserControl_variableItem>();

            // Global Variables
            UserControl_funcPanel f1 = makeFuncPanel("Global Frame", step.Globals, dict);
            myVariable.Children.Add(f1);

            // Local Variables
            List<List<C_VARIABLE>> stack = step.getLocals();
            List<string> func_names = step.getFuncs();
            for (int i = 0; i < stack.Count; i++)
            {
                UserControl_funcPanel f2 = makeFuncPanel(func_names[i], stack[i], dict);
                myVariable.Children.Add(f2);
            }

            // Heap
            List<C_VARIABLE> heap = step.Heap;
            UserControl_funcPanel f3 = makeFuncPanel("Heap", heap, dict);
            myHeap.Children.Add(f3);


            // Pointer to Value
            RandomColorGenerator rcg = new RandomColorGenerator();
            foreach (var funcPanel in myVariable.Children)  //VARIABLES PART
            {
                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
                pointerProcess(uc, dict, rcg);
            }
            foreach (var funcPanel in myHeap.Children)  //HEAP PART
            {
                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
                pointerProcess(uc, dict, rcg);
            }
        }

        //public Trace Draw_All(Visual visual, int run_current_count)
        //{
        //    foreach (Trace step in visual.Trace)
        //    {
        //        if (run_current_count == step.Line)
        //        {
        //            init();

        //            Dictionary<string, UserControl_variableItem> dict = new Dictionary<string, UserControl_variableItem>();

        //            // Global Variables
        //            UserControl_funcPanel f1 = makeFuncPanel("Global Frame", step.Globals, dict);
        //            myVariable.Children.Add(f1);

        //            // Local Variables
        //            List<List<C_VARIABLE>> stack = step.getLocals();
        //            List<string> func_names = step.getFuncs();
        //            for (int i = 0; i < stack.Count; i++)
        //            {
        //                UserControl_funcPanel f2 = makeFuncPanel(func_names[i], stack[i], dict);
        //                myVariable.Children.Add(f2);
        //            }

        //            // Heap
        //            List<C_VARIABLE> heap = step.Heap;
        //            UserControl_funcPanel f3 = makeFuncPanel("Heap", heap, dict);
        //            myHeap.Children.Add(f3);


        //            // Pointer to Value
        //            RandomColorGenerator rcg = new RandomColorGenerator();
        //            foreach (var funcPanel in myVariable.Children)  //VARIABLES PART
        //            {
        //                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
        //                pointerProcess(uc, dict, rcg);
        //            }
        //            foreach (var funcPanel in myHeap.Children)  //HEAP PART
        //            {
        //                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
        //                pointerProcess(uc, dict, rcg);
        //            }

        //            return step;

        //        }
        //        else if (run_current_count == 0)
        //        {
        //            init();

        //            Dictionary<string, UserControl_variableItem> dict = new Dictionary<string, UserControl_variableItem>();

        //            // Global Variables
        //            UserControl_funcPanel f1 = makeFuncPanel("Global Frame", step.Globals, dict);
        //            myVariable.Children.Add(f1);

        //            // Heap
        //            List<C_VARIABLE> heap = step.Heap;
        //            UserControl_funcPanel f3 = makeFuncPanel("Heap", heap, dict);
        //            myHeap.Children.Add(f3);


        //            // Pointer to Value
        //            RandomColorGenerator rcg = new RandomColorGenerator();
        //            foreach (var funcPanel in myVariable.Children)  //VARIABLES PART
        //            {
        //                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
        //                pointerProcess(uc, dict, rcg);
        //            }
        //            foreach (var funcPanel in myHeap.Children)  //HEAP PART
        //            {
        //                UserControl_funcPanel uc = funcPanel as UserControl_funcPanel;
        //                pointerProcess(uc, dict, rcg);
        //            }
        //        }
        //    }

        //    return null;
        //}


        private UserControl_funcPanel makeFuncPanel(string name, List<C_VARIABLE> vars, Dictionary<string, UserControl_variableItem> dict)
        {
            UserControl_funcPanel f = new UserControl_funcPanel();
            f.setLabel(name);

            foreach (var item in vars)
            {
                if (item is C_DATA) //primitive
                {
                    UserControl_variable uc = new UserControl_variable();
                    C_DATA variable = item as C_DATA;

                    List<C_DATA> list = new List<C_DATA>();
                    list.Add(variable);

                    uc.AddValues(list, dict);

                    uc.setName(variable.Name);

                    f.Add(uc);
                }
                else
                {
                    UserControl_variable uc = new UserControl_variable();
                    C_ARRAY ca = item as C_ARRAY;

                    uc.AddValues(ca.Values, dict);

                    uc.setName(ca.Name);

                    f.Add(uc);
                }
            }

            return f;
        }

        private void pointerProcess(UserControl_funcPanel fPanel, Dictionary<string, UserControl_variableItem> dict, RandomColorGenerator rcg)
        {
            foreach (var item in fPanel.getPanelChildren())
            {
                if (item is UserControl_variable)
                {
                    UserControl_variable arr = item as UserControl_variable;
                    List<C_DATA> dataChildren = arr.getArrayChildren();
                    if (dataChildren != null)
                    {
                        var panelChildren = arr.getPanelChildren();
                        int count = dataChildren.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (dataChildren[i].Type == "pointer")
                            {
                                UserControl_variableItem source = panelChildren[i] as UserControl_variableItem;
                                if (dict.ContainsKey(dataChildren[i].Value))
                                {
                                    UserControl_variableItem target = dict[dataChildren[i].Value];
                                    C_DATA data = target.Data;
                                    if (source != null)
                                    {
                                        string val = StringFunc.toBeauty(data.Value, data.Type == "char");
                                        source.setText(val);

                                        SolidColorBrush scb = rcg.next();
                                        target.val.Foreground = scb;
                                        source.val.Foreground = scb;
                                    }
                                }
                                else
                                {
                                    source.setBackgroundNULL();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
