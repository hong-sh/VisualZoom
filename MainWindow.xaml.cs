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
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using System.Threading;

namespace BoyeoZoom
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {


        //private int count = 0;
        private int run_total_count;
        private int run_current_count;
        private int current_step_index;

        private Visual visual;
        private List<Flow> items;
        private string json;

        bool serverComplete;


        private string textedit;
        public string textedit_text
        {
            get
            {
                return textedit;
            }
            set { textedit = value; }
        }

        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            run_total_count = 0;
            run_current_count = 0;
            current_step_index = 0;

            items = new List<Flow>();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += DoWork;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void Grid_visualize_Loaded(object sender, RoutedEventArgs e)
        {
            Grid_visualize.Children.Add(new UserControl_visualize());
        }

        private void Grid_efficiency_Loaded(object sender, RoutedEventArgs e)
        {
            Grid_efficiency.Children.Add(new UserControl_efficiency());
        }

        private void Grid_diagrammatic_Loaded(object sender, RoutedEventArgs e)
        {
            Grid_diagrammatic.Children.Add(new UserControl_diagrammatic());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        string currentFileName;

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                currentFileName = dlg.FileName;
                uc_input.textEditor.Load(currentFileName);
                uc_input.textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(currentFileName));
            }
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {

            if (currentFileName == null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".c";
                if (dlg.ShowDialog() ?? false)
                {
                    currentFileName = dlg.FileName;
                }
                else
                {
                    return;
                }
            }

            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            uc_input.textEditor.Save(currentFileName);

        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_inputCode_Loaded(object sender, RoutedEventArgs e)
        {
            Grid_inputCode.Children.Add(new UserControl_inputCode());
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (currentFileName == null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".c";
                if (dlg.ShowDialog() ?? false)
                {
                    currentFileName = dlg.FileName;
                }
                else
                {
                    return;
                }
            }

            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            uc_input.textEditor.Save(currentFileName);
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                currentFileName = dlg.FileName;
                uc_input.textEditor.Load(currentFileName);
                uc_input.textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(currentFileName));
            }
        }

        private void initAll()
        {
            UserControl_visualize uc_visual = FindVisualChildren<UserControl_visualize>(this).ToArray()[0];
            uc_visual.init();

            Draw_Print("");

            UserControl_diagrammatic uc_d = FindVisualChildren<UserControl_diagrammatic>(this).ToArray()[0];
            uc_d.init();

            DrawLineInTextEditor(0);

        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;

            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            textedit = uc_input.textEditor.Text;
            run_total_count = uc_input.textEditor.LineCount;
            run_current_count = 0;
            current_step_index = 0;

            initAll();

            backgroundWorker.RunWorkerAsync();
            
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.progressBar.Value = e.ProgressPercentage % 100;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {

            serverComplete = false;
            Thread serverThread = new Thread(new ThreadStart(ServerThread));
            serverThread.Start();

            int i = 0;
            while (true) {
                if (serverComplete == true)
                    break;

                backgroundWorker.ReportProgress(i);
                Thread.Sleep(50);
                i++;
            }

        }

        public void ServerThread()
        {
            string code = textedit;
            byte[] byteArray = Encoding.ASCII.GetBytes(code);

            string fileName;
            fileName = DateTime.Now.ToString("yyyyMMddhhmmssffffff") + ".c";

            // Draw All
            json = getJsonFromServer(byteArray, fileName);

            items.Clear();
            Server server = new Server(byteArray, fileName);
            items = server.getItems();

            serverComplete = true;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visibility = Visibility.Hidden;
            if (json == null || items.Count == 0)
            {
                MessageBox.Show("Internet Connection Error");
            }
            else
            {

                prestep.IsEnabled = true;
                step.IsEnabled = true;

                visual = JsonConvert.DeserializeObject<Visual>(json, new VisualConverter());

                // Draw Time And Memory Usage Part
                DrawTimeAndMemory(visual.Time, visual.MemUsage);


                if (visual.IsError())
                {
                    // Draw_Print(visual.getAllErrors());
                    MessageBox.Show("" + visual.getAllErrors(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    DrawLineInTextEditor(visual.getErrorLine());
                }
                else 
                {
                    // Draw MemoryFlow Part
                    UserControl_visualize uc_visual = FindVisualChildren<UserControl_visualize>(this).ToArray()[0];
                    //uc_visual.Draw_All(visual, run_current_count);
                    Trace step = visual.Trace[current_step_index];
                    uc_visual.Draw_All(step);

                    // Draw FlowChart Part
                    UserControl_diagrammatic uc_d = FindVisualChildren<UserControl_diagrammatic>(this).ToArray()[0];
                    uc_d.draw_flowchart(items);

                    Draw_Print(visual.getAllStdout());
                }
                

            }
    
        }

        private string getJsonFromServer(byte[] data, string name)
        {
            var client = new RestClient(@"http://cgac-group.cbnu.ac.kr:8080/");
            var request = new RestRequest("visualize/", Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddFile("file", data, name);
            request.AddParameter("name", name);

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content;
                return content;
            }
             return null;
        }

        private void DrawTimeAndMemory(string time, long mem)
        {
            UserControl_efficiency uc_eff = FindVisualChildren<UserControl_efficiency>(this).ToArray()[0];

            double realMem = mem - 4000;
            if (realMem < 0) realMem = 0;
            string retMem;
            if (realMem > 10000)
            {
                realMem = realMem / 1000;
                retMem = "" + realMem + " MB";
            }
            else
            {
                retMem = "" + realMem + " KB";
            }


            string[] str = time.Split(':');
            string retTime = str[0] + "m " + str[1] + "s";


            uc_eff.text_excute.Text = retTime;
            uc_eff.text_memory.Text = retMem;

        }

        private void prestep_Click(object sender, RoutedEventArgs e)
        {
            if (!visual.IsError())
            {
                if (run_current_count > 0 && current_step_index > 0)
                {
                    current_step_index--;
                    run_current_count = visual.Trace[current_step_index].Line;
                }

                // Draw MemoryFlow Part
                UserControl_visualize uc_visual = FindVisualChildren<UserControl_visualize>(this).ToArray()[0];
                //Trace step = uc_visual.Draw_All(visual, run_current_count);
                
                //if (step != null)
                if (current_step_index > 0 && current_step_index < visual.Trace.Count)
                {
                    Trace step = visual.Trace[current_step_index];
                    uc_visual.Draw_All(step);

                    Draw_Print(step.Stdout);

                    UserControl_diagrammatic uc_d = FindVisualChildren<UserControl_diagrammatic>(this).ToArray()[0];
                    uc_d.draw_flowchart(items, step.Line);
                }

                // Draw Current Line in TextEditor
                DrawLineInTextEditor(run_current_count);
            }
        }

        private void step_Click(object sender, RoutedEventArgs e)
        {
            if (!visual.IsError())
            {
                if (run_current_count < run_total_count && current_step_index < visual.Trace.Count)
                {
                    current_step_index++;
                    run_current_count = visual.Trace[current_step_index].Line;
                }

                // Draw MemoryFlow Part
                UserControl_visualize uc_visual = FindVisualChildren<UserControl_visualize>(this).ToArray()[0];
                //Trace step = uc_visual.Draw_All(visual, current_step_index);
                Trace step = visual.Trace[current_step_index];
                uc_visual.Draw_All(step);
            
                if (step != null)
                {
                    Draw_Print(step.Stdout);

                    // Draw FlowChart Part
                    UserControl_diagrammatic uc_d = FindVisualChildren<UserControl_diagrammatic>(this).ToArray()[0];
                    uc_d.draw_flowchart(items, step.Line);
                }

                // Draw Current Line in TextEditor
                DrawLineInTextEditor(run_current_count);
            }

        }

        private void DrawLineInTextEditor(int current_count)
        {
            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            if (uc_input.textEditor.TextArea.TextView.LineTransformers.Count == 1)
                uc_input.textEditor.TextArea.TextView.LineTransformers.RemoveAt(0);
            uc_input.textEditor.TextArea.TextView.LineTransformers.Add(new LineColorizer(current_count));
        }

        private void Draw_Print(string stdout)
        {
            UserControl_print uc_print = FindVisualChildren<UserControl_print>(this).ToArray()[0];

            uc_print.printLabel.Content = stdout;
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            uc_input.textEditor.Undo();
        }

        private void redo_Click(object sender, RoutedEventArgs e)
        {
            UserControl_inputCode uc_input = FindVisualChildren<UserControl_inputCode>(this).ToArray()[0];
            uc_input.textEditor.Redo();
        }

        private void Grid_print_Loaded(object sender, RoutedEventArgs e)
        {
            Grid_print.Children.Add(new UserControl_print());
        }

    }

}
