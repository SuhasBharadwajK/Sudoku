using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.Media;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sudoku
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Canvas rootcanvas = new Canvas();
        //rootcanvas.Width = 400;
        //rootcanvas.Height = 400;
        
        Rectangle rekt = new Rectangle();
        SolidColorBrush blueBrush = new SolidColorBrush(Windows.UI.Colors.Blue);
        public MainPage()
        {
            this.InitializeComponent();
            //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
        }

        private void BoxTapped(object sender, TappedRoutedEventArgs e)
        {
            string senderInfo = ((TextBlock)sender).Name;
            int p = Int32.Parse(senderInfo.Substring(3, 1));
            int q = Int32.Parse(senderInfo.Substring(5, 1));
            int r = Int32.Parse(senderInfo.Substring(7, 1));
            int s = Int32.Parse(senderInfo.Substring(9, 1));
            ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + 1 + "x" + 1 + "_1x1")).Text = "\n25";

            double x = Canvas.GetLeft((TextBlock)sender);
            double y = Canvas.GetTop((TextBlock)sender);

            /*
                * For Right Up(ru): x + 30, y - 130
                * For Right Down(rd): x + 30, y + 30
                * For Left Up(lu): x - 130, y - 130
                * For Left Down(ld): x - 130, y + 30
                *    
             */

            if (p == 1 && q == 1)
            {
                Canvas.SetLeft(menu1x1_1x1, x + 30);
                Canvas.SetTop(menu1x1_1x1, y + 30);
                expand_rd.Begin();
            }

            else if (p == 1 && q == 2)
            {
                if (s <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y + 30);
                    expand_rd.Begin();
                }

                else
                {
                    Canvas.SetLeft(menu1x1_1x1, x - 130);
                    Canvas.SetTop(menu1x1_1x1, y + 30);
                    expand_ld.Begin();
                }
            }

            else if (p == 1 && q == 2)
            {
                Canvas.SetLeft(menu1x1_1x1, x - 130);
                Canvas.SetTop(menu1x1_1x1, y + 30);
                expand_ld.Begin();
            }

            else if (p == 2 && q == 1)
            {
                if (r <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y + 30);
                    expand_rd.Begin();
                }

                else
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y - 130);
                    expand_ru.Begin();
                }
            }

            else if (p == 2 && q == 2)
            {
                if (r <= 2 && s <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y + 30);
                    expand_rd.Begin();
                }

                else if (s == 3 && r <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x - 130);
                    Canvas.SetTop(menu1x1_1x1, y + 30);
                    expand_ld.Begin();
                }

                else if (r == 3 && s <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y - 130);
                    expand_ru.Begin();
                }

                else
                {
                    Canvas.SetLeft(menu1x1_1x1, x - 130);
                    Canvas.SetTop(menu1x1_1x1, y - 130);
                    expand_lu.Begin();
                }
            }

            else if (p == 3 && q == 1)
            {
                Canvas.SetLeft(menu1x1_1x1, x + 30);
                Canvas.SetTop(menu1x1_1x1, y - 130);
                expand_ru.Begin();
            }

            else if (p == 3 && q == 2)
            {
                if (s <= 2)
                {
                    Canvas.SetLeft(menu1x1_1x1, x + 30);
                    Canvas.SetTop(menu1x1_1x1, y - 130);
                    expand_ru.Begin();
                }

                else
                {
                    Canvas.SetLeft(menu1x1_1x1, x - 130);
                    Canvas.SetTop(menu1x1_1x1, y - 130);
                    expand_lu.Begin();
                }
            }

            else
            {
                Canvas.SetLeft(menu1x1_1x1, x - 130);
                Canvas.SetTop(menu1x1_1x1, y - 130);
                expand_lu.Begin();
            }

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Canvas.SetLeft((Windows.UI.Xaml.Controls.TextBlock)this.FindName("o_" + i + "x" + j), Canvas.GetLeft(menu1x1_1x1) + (20 + (50 * (j - 1))));
                    Canvas.SetTop((Windows.UI.Xaml.Controls.TextBlock)this.FindName("o_" + i + "x" + j), Canvas.GetTop(menu1x1_1x1) + (15 + (50 * (i - 1))));
                }
            }

            if (senderInfo.Substring(3, 1) == "1" || senderInfo.Substring(3, 1) == "3" || senderInfo.Substring(3, 1) == "2")
            {
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Visibility = Visibility.Collapsed;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).IsTapEnabled = false;
                //Canvas.SetLeft(textBox, 500);
                //expand_1x1_1x2.Begin();
                //rekt.Fill = SolidColorBrush.ColorProperty.GetHashCode("#000");
                //rekt.Fill = blueBrush;
                //Canvas.SetLeft(rekt, 500);
                //Canvas.SetTop(rekt, 500);
                //rootcanvas.Children.Add(rekt);
                //rekt.Height = 300;
                //rekt.Width = 200;
                //Canvas.SetLeft(menu1x1_1x1, 500);
                //Canvas.SetTop(menu1x1_1x1, 500);

                //double x = Canvas.GetLeft((TextBlock)sender);
                //double y = Canvas.GetTop((TextBloc)sender);
                //Canvas.SetLeft(menu1x1_1x1, x - 130);
                //Canvas.SetTop(menu1x1_1x1, y - 130);
                //for (int i = 1; i <= 3; i++)
                //{
                //    for (int j = 1; j <= 3; j++)
                //    {
                //        Canvas.SetLeft((Windows.UI.Xaml.Controls.TextBlock)this.FindName("o_" + i + "x" + j), Canvas.GetLeft(menu1x1_1x1) + (20 + (50 * (j - 1))));
                //        Canvas.SetTop((Windows.UI.Xaml.Controls.TextBlock)this.FindName("o_" + i + "x" + j), Canvas.GetTop(menu1x1_1x1) + (15 + (50 * (i - 1))));
                //    }
                //}
                textBox.Text = x + ", " + y;
                //expand_lu.Begin();
            }
            //else if (senderInfo.Substring(3, 1) == "2")
            //{ 
            //    //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
            //    //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Visibility = Visibility.Collapsed;
            //    //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).IsTapEnabled = false;
            //    //Canvas.SetLeft(textBox, 500);
            //    //expand_1x1_1x2_R.Begin();
            //    expand_1x1_1x1_R.Begin();
            //}
            //(
            
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ((Windows.UI.Xaml.Controls.TextBox)this.FindName("textBox")).Text = "Suhas";
        }

        private void Rev_Click(object sender, RoutedEventArgs e)
        {
            expand_R.Begin();
        }
    }
}
