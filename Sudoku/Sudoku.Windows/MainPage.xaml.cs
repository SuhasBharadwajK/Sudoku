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
        //Canvas rootcanvas = new Canvas();
        //rootcanvas.Width = 400;
        //rootcanvas.Height = 400;
        
        //Rectangle rekt = new Rectangle();
        //SolidColorBrush blueBrush = new SolidColorBrush(Windows.UI.Colors.Blue);

        int positionX, positionY, subPositionX, subPositionY, animFlag = 0;
        //int[,,] game = new int[,,] {{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }};
        //int[, , ,] game = new int[3, 3, 3, 3];
        //public Dictionary<int, Dictionary<int, >>
        //public List<Dictionary<string, bool>> grid, row, column = new List<Dictionary<string, bool>>();
        public List<Dictionary<string, Dictionary<int, bool>>> gridStatus = new List<Dictionary<string, Dictionary<int, bool>>> 
        {
            new Dictionary<string, Dictionary<int, bool>> 
            {
                {"11", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"12", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"13", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"21", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"22", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"23", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"31", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"32", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"33", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}}
            },

            new Dictionary<string, Dictionary<int, bool>> 
            {
                {"11", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"12", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"13", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"21", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"22", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"23", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"31", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"32", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"33", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}}
            },

            new Dictionary<string, Dictionary<int, bool>> 
            {
                {"11", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"12", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"13", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"21", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"22", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"23", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"31", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"32", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}},
                {"33", new Dictionary<int, bool> {{1, false}, {2, false}, {3, false}, {4, false}, {5, false}, {6, false}, {7, false}, {8, false}, {9, false}}}
            }
        };
        //= new List<Dictionary<string, Dictionary<int, bool>>>() 
        //{
        //    new Dictionary<string, Dictionary<int, bool>>() 
        //    {
        //        {"1111", new Dictionary<int, bool> {{7, false}, {5, false}}}
        //    },
        //    new Dictionary<string, Dictionary<int, bool>>() 
        //    {
        //        //"asdf", new Dictionary<int, bool>() {7, false};
        //    }
        //};
        //public Dictionary<int, bool> dict1 = new Dictionary<int, bool>();
        //public Dictionary<string, Dictionary<int, bool>> dict = new Dictionary<string, Dictionary<int, bool>> 
        //{
        //     {"1111", new Dictionary<int, bool> {{7, false}, {5, false}}}
        //};

        public MainPage()
        {
            this.InitializeComponent();
            //gridStatus.Add(new Dictionary<string, Dictionary<int, bool>> { "11", new Dictionary<int, bool> { {"7", false} } });
            //gridStatus[1]["11"][8] = false;
            populate();
            //num1x1_2x1.Tapped += back;
            //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
        }

        public void back(object sender, TappedRoutedEventArgs e)
        {
            expand_R.Begin();
            animFlag = 0;
        }

        private void BoxTapped(object sender, TappedRoutedEventArgs e)
        {
            string senderInfo = ((TextBlock)sender).Name;

            int p = Int32.Parse(senderInfo.Substring(3, 1));
            int q = Int32.Parse(senderInfo.Substring(5, 1));
            int r = Int32.Parse(senderInfo.Substring(7, 1));
            int s = Int32.Parse(senderInfo.Substring(9, 1));

            positionX = p;
            positionY = q;
            subPositionX = r;
            subPositionY = s;

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

            /*
             * 
             */
            if (animFlag == 0)
            {
                animFlag = 1;

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

                else if (p == 1 && q == 3)
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

                else if (p == 2 && q == 3)
                {
                    if (r <= 2)
                    {
                        Canvas.SetLeft(menu1x1_1x1, x - 130);
                        Canvas.SetTop(menu1x1_1x1, y + 30);
                        expand_ld.Begin();
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
            }

            else
            {
                animFlag = 0;
                expand_R.Begin();
                //BoxTapped(sender, e);
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

        private void populate()
        {
            Random rand = new Random();

            //for (int i = 1; i <= 3; i++)
            //{
            //    for (int j = 1; j <= 3; j++)
            //    {
            //        for (int n = 1; n <= 9; n++)
            //        {
            //            gridStatus = 
            //            //gridStatus[1][i.ToString() + j.ToString()][n] = false;
            //            //gridStatus[2][i.ToString() + j.ToString()][n] = false;
            //            //gridStatus[3][i.ToString() + j.ToString()][n] = false;
            //            //gridStatus.Add(new )
            //        }
            //        //for (int k = 1; k <= 3; k++)
            //        //{
            //        //    for (int n = 1; n <= 9; n++)
            //        //    {
            //        //        gridStatus[i][j.ToString() + k.ToString()][n] = false;
            //        //    }
            //        //    //for (int l = 1; l <= 3; l++)
            //        //    //{

            //        //    //}
            //        //}
            //    }
            //}

            for (int l = 1; l <= 3; l++)
            {
                for (int k = l; k <= 3; k++)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        int flag = 0;
                        for (int j = 1; j <= 3; j++)
                        {
                            
                            int num = rand.Next(1, 10);
                            if (!check(num, l.ToString() + k.ToString() + i.ToString() + j.ToString()))
                            {
                                ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + l + "x" + k + "_" + i + "x" + j)).Text = "\n" + num;
                                gridStatus[0][l.ToString() + k.ToString()][num] = true;
                                gridStatus[1][k.ToString() + j.ToString()][num] = true;
                                gridStatus[2][l.ToString() + i.ToString()][num] = true;
                                flag = 1;
                            }

                            else
                            {
                                j--;
                                continue;
                            }
                            int num2 = rand.Next(1, 10);
                            if (!check(num2, l.ToString() + k.ToString() + i.ToString() + j.ToString()) && i != j)
                            {
                                ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + k + "x" + l + "_" + j + "x" + i)).Text = "\n" + num2;
                                gridStatus[0][l.ToString() + k.ToString()][num2] = true;
                                gridStatus[1][k.ToString() + j.ToString()][num2] = true;
                                gridStatus[2][l.ToString() + i.ToString()][num2] = true;
                                flag = 0;
                            }

                            else
                            {
                                j--;
                                continue;
                            }
                            
                            //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + l + "x" + k + "_" + i + "x" + j)).Text = "\n" + rand.Next(1, 10);
                            //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + k + "x" + l + "_" + j + "x" + i)).Text = "\n" + rand.Next(1, 10);
                            ////((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + (i + 1) + "x" + 1 + "_" + 1 + "x" + 1)).Text = "\n" + rand.Next(10, 20);  
                        }
                    }
                }
            }

            //for (int i = 1; i <= 3; i++)
            //{
            //    for (int j = 1; j <= 3; j++)
            //    {
            //        if (true)
            //        {
            //            ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + i + "x" + 1 + "_" + j + "x" + 1)).Text = "\n" + rand.Next(11, 20);
            //        }
            //    }
            //}
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + positionX + "x" + positionY + "_" + subPositionX + "x"+ subPositionY)).Text = "\n" + ((TextBlock)sender).Text;
            ((Windows.UI.Xaml.Controls.TextBlock)this.FindName("num" + positionX + "x" + positionY + "_" + subPositionX + "x" + subPositionY)).Foreground = myCol;
            animFlag = 0;
            expand_R.Begin();
            ((Windows.UI.Xaml.Controls.TextBox)this.FindName("textBox")).Text = "Suhas";
        }

        private void RektBackIsTapped(object sender, TappedRoutedEventArgs e)
        {
            animFlag = 0;
            expand_R.Begin();
        }

        private bool check(int number, string id)
        {
            string x = id.Substring(0, 1);
            string y = id.Substring(1, 1);
            string z = id.Substring(2, 1);
            string w = id.Substring(3, 1);
            if (gridStatus[0][x + y][number] && gridStatus[1][x + z][number] && gridStatus[2][y + w][number])
            {
                return true;
            }
            return false;
        }
    }
}
