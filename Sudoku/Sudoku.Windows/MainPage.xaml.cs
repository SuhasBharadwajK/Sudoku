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
            if (senderInfo.Substring(3, 1) == "1")
            {
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Visibility = Visibility.Collapsed;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).IsTapEnabled = false;
                //Canvas.SetLeft(textBox, 500);
                //expand_1x1_1x2.Begin();
                //rekt.Fill = SolidColorBrush.ColorProperty.GetHashCode("#000");
                rekt.Fill = blueBrush;
                Canvas.SetLeft(rekt, 500);
                Canvas.SetTop(rekt, 500);
                rootcanvas.Children.Add(rekt);
                rekt.Height = 300;
                rekt.Width = 200;
                Canvas.SetLeft(menu1x1_1x1, 500);
                Canvas.SetTop(menu1x1_1x1, 500);
                
                expand_1x1_1x1.Begin();
            }
            else if (senderInfo.Substring(3, 1) == "2")
            {
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Opacity = 0;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).Visibility = Visibility.Collapsed;
                //((Windows.UI.Xaml.Controls.TextBlock)this.FindName("textBlock_Copy")).IsTapEnabled = false;
                //Canvas.SetLeft(textBox, 500);
                //expand_1x1_1x2_R.Begin();
                expand_1x1_1x1_R.Begin();
            }
            //(
            
        }

        private void textBlock_Copy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ((Windows.UI.Xaml.Controls.TextBox)this.FindName("textBox")).Text = "Suhas";
        }
    }
}
