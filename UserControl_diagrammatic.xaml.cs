using BoyeoZoom.flowchart_usercontrol;
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
    /// UserControl_diagrammatic.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl_diagrammatic : UserControl
    {

        List<int> arrowPosition;
        private double StartPositionTop;
        private double StartPositionLeft;
        private double StartPointRight;

        public UserControl_diagrammatic()
        {
            arrowPosition = new List<int>();
            InitializeComponent();
        }

        public void init() {
            canvas_flowchart.Children.Clear();
        }

        public void drawArrow(Flow flow)
        {

            UserControl_arrowB userControl_arrowB = new UserControl_arrowB(StartPositionTop, flow.StartLine);

            Canvas.SetLeft(userControl_arrowB, StartPositionLeft);
            Canvas.SetTop(userControl_arrowB, StartPositionTop);
            StartPositionTop += 30.0;

            canvas_flowchart.Children.Add(userControl_arrowB);
            arrowPosition.Add(canvas_flowchart.Children.Count - 1);
        }

        public void arrowChagne(int line)
        {
            for (int i = 0; i < arrowPosition.Count; i++)
            {
                UserControl_arrowB userControl_arrowB = (UserControl_arrowB)canvas_flowchart.Children[arrowPosition[i]];
                if (userControl_arrowB.GetStartLine() == line)
                {
                    userControl_arrowB.SetBackground(1);
                    canvas_scroll.ScrollToVerticalOffset(userControl_arrowB.GetTop() - 90);
                    return;
                }
                else
                {
                    userControl_arrowB.SetBackground(0);
                }
            }
        }

        public void draw(Flow flow, int count)
        {
            if (count != 0)
                drawArrow(flow);

            canvas_scroll.ScrollToTop();

            string[] splitType = flow.Type.Split(':');

            if (splitType[0].Equals("FunctionStart"))
            {
                UserControl_startEnd userControl_startEnd = new UserControl_startEnd(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_startEnd, StartPositionLeft);
                Canvas.SetTop(userControl_startEnd, StartPositionTop);
                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_startEnd);
            }

            if (splitType[0].Equals("FunctionStop"))
            {

                UserControl_startEnd userControl_startEnd = new UserControl_startEnd(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_startEnd, StartPositionLeft);
                Canvas.SetTop(userControl_startEnd, StartPositionTop);
                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_startEnd);
            }

            if (splitType[0].Equals("Declaration"))
            {

                UserControl_ready userControl_ready = new UserControl_ready(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_ready, StartPositionLeft);
                Canvas.SetTop(userControl_ready, StartPositionTop);
                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_ready);
            }

            if (splitType[0].Equals("Selection") || splitType[0].Equals("Labeled"))
            {

                UserControl_selection userControl_selection = new UserControl_selection(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_selection, StartPositionLeft);
                Canvas.SetTop(userControl_selection, StartPositionTop);
                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_selection);

                string text2 = "";
                for (int i = 0; i < flow.getList().Count; i++)
                {
                    text2 += flow.getList()[i].GetText() + "\n";
                }

                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPositionLeft + 190);
                Canvas.SetTop(userControl_arrowR, StartPositionTop - 70);

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_expression userControl_expression = new UserControl_expression(StartPositionLeft, StartPositionTop - 70, flow);
                userControl_expression.setText(text2);

                Canvas.SetLeft(userControl_expression, StartPositionLeft + 220);
                Canvas.SetTop(userControl_expression, StartPositionTop - 70);

                canvas_flowchart.Children.Add(userControl_expression);


            }
            if (splitType[0].Equals("Iteration"))
            {

                UserControl_Iteration userControl_iteration = new UserControl_Iteration(StartPositionLeft, StartPositionTop, flow);

                string text2 = "";
                for (int i = 0; i < flow.getList().Count; i++)
                {
                    text2 += flow.getList()[i].GetText() + "\n";
                }

                userControl_iteration.SetText2(text2);

                Canvas.SetLeft(userControl_iteration, StartPositionLeft);
                Canvas.SetTop(userControl_iteration, StartPositionTop);
                StartPositionTop += 110.0;

                canvas_flowchart.Children.Add(userControl_iteration);
                canvas_flowchart.Height += 60;

            }

            if (splitType[0].Equals("Expression"))
            {

                UserControl_expression userControl_expression = new UserControl_expression(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_expression, StartPositionLeft);
                Canvas.SetTop(userControl_expression, StartPositionTop);

                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_expression);
            }

            if (splitType[0].Equals("Function")) {

                UserControl_func_call userControl_func_call = new UserControl_func_call(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_func_call, StartPositionLeft);
                Canvas.SetTop(userControl_func_call, StartPositionTop);

                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_func_call);
            }

            if (splitType[0].Equals("Return")) {

                UserControl_return userControl_return = new UserControl_return(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_return, StartPositionLeft);
                Canvas.SetTop(userControl_return, StartPositionTop);

                StartPositionTop += 70.0;

                canvas_flowchart.Children.Add(userControl_return);
            }

            canvas_flowchart.Height += 100;
        }

        public void drawRight(Flow flow, double StartPositionTop)
        {

            string[] splitType = flow.Type.Split(':');

            if (splitType[0].Equals("Declaration"))
            {
                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_ready userControl_ready = new UserControl_ready(StartPointRight, StartPositionTop, flow);

                Canvas.SetLeft(userControl_ready, StartPointRight);
                Canvas.SetTop(userControl_ready, StartPositionTop);
                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_ready);
            }

            if (splitType[0].Equals("Selection"))
            {

                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_selection userControl_selection = new UserControl_selection(StartPointRight, StartPositionTop, flow);

                Canvas.SetLeft(userControl_selection, StartPointRight);
                Canvas.SetTop(userControl_selection, StartPositionTop);
                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_selection);


            }
            if (splitType[0].Equals("Iteration"))
            {

                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_Iteration userControl_iteration = new UserControl_Iteration(StartPointRight, StartPositionTop, flow);

                string text2 = "";
                for (int i = 0; i < flow.getList().Count; i++)
                {
                    text2 += flow.getList()[i].GetText() + "\n";
                }

                userControl_iteration.SetText2(text2);

                Canvas.SetLeft(userControl_iteration, StartPointRight);
                Canvas.SetTop(userControl_iteration, StartPositionTop);
                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_iteration);

            }

            if (splitType[0].Equals("Expression"))
            {

                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_expression userControl_expression = new UserControl_expression(StartPointRight, StartPositionTop, flow);

                Canvas.SetLeft(userControl_expression, StartPointRight);
                Canvas.SetTop(userControl_expression, StartPositionTop);

                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_expression);
            }

            if (splitType[0].Equals("Function"))
            {


                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_func_call userControl_func_call = new UserControl_func_call(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_func_call, StartPositionLeft);
                Canvas.SetTop(userControl_func_call, StartPositionTop);

                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_func_call);
            }

            if (splitType[0].Equals("Return"))
            {

                UserControl_arrowR userControl_arrowR = new UserControl_arrowR(flow.StartLine);

                Canvas.SetLeft(userControl_arrowR, StartPointRight);
                Canvas.SetTop(userControl_arrowR, StartPositionTop);
                StartPointRight += 30.0;

                canvas_flowchart.Children.Add(userControl_arrowR);

                UserControl_return userControl_return = new UserControl_return(StartPositionLeft, StartPositionTop, flow);

                Canvas.SetLeft(userControl_return, StartPositionLeft);
                Canvas.SetTop(userControl_return, StartPositionTop);

                StartPointRight += 190.0;

                canvas_flowchart.Children.Add(userControl_return);
            }

            canvas_flowchart.Width += 220;
        }

        public void draw_flowchart(List<Flow> items)
        {

            StartPositionTop = 20;
            StartPositionLeft = 50;

            canvas_flowchart.Children.Clear();
            canvas_flowchart.Height = 0;

            int count = 0;

            for (int i = 0; i < items.Count; i++)
            {
                draw(items[i], count);
                count++;
                string[] split = items[i].GetType().Split(':');
                List<Flow> child = items[i].flows;
                for (int j = 0; j < child.Count; j++)
                {
                    if (split[0].Equals("Selection") || split[0].Equals("Labeled"))
                    {
                        StartPointRight = StartPositionLeft + 190 + (j * 220);
                        if (j == 0)
                            canvas_flowchart.Children.RemoveAt(canvas_flowchart.Children.Count - 1);
                        drawRight(child[j], StartPositionTop - 70);
                    }
                    /*else if (split[0].Equals("Labeled")) {
                        StartPointRight = StartPositionLeft + 190 + (j * 220);
                        drawRight(child[j], StartPositionTop - 70);
                    }*/
                    else
                    {
                        draw(child[j], count);
                        count++;
                    }
                }

            }
        }

        public void draw_flowchart(List<Flow> items, int count)
        {


            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetStartLine() <= count && items[i].GetStopLine() >= count)
                {
                    List<Flow> child = items[i].getList();
                    for (int j = 0; j < child.Count; j++)
                    {
                        if (child[j].GetStartLine() > count)
                        {
                            draw_flowchart(items);
                        }
                        else if (child[j].GetStartLine() <= count && child[j].GetStopLine() >= count
                            && child[j].getList().Count > 0)
                        {
                            draw_flowchart(child[j].getList(), count);
                            return;
                        }
                    }
                }
            }

            arrowChagne(count);
        }


    }
}
