using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
namespace App2
{
    public sealed partial class MainPage : Page
    {
        int i = 0;
        ObservableCollection<Item> OldItem = new ObservableCollection<Item>();
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Equal
        {

            if (TextBlock1.Text == null)
            {
                TextBlock1.Text = "";
                TextBlock2.Text = "0";
            }
            else
            {
                TextBlock2.Text = Convert.ToString(Calculate.Calculater1(TextBlock1.Text));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Num1
        {
            TextBlock1.Text += "1";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Num2
        {
            TextBlock1.Text += "2";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Num3
        {
            TextBlock1.Text += "3";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Num4
        {
            TextBlock1.Text += "4";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //Num5
        {
            TextBlock1.Text += "5";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) //Num6
        {
            TextBlock1.Text += "6";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) //Num7
        {
            TextBlock1.Text += "7";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) //Num8
        {
            TextBlock1.Text += "8";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e) //Num9
        {
            TextBlock1.Text += "9";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e) //Point
        {
            TextBlock1.Text += ".";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e) //Num0
        {
            TextBlock1.Text += "0";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e) //Num00
        {
            TextBlock1.Text += "00";
        }

        private void Button_Click_13(object sender, RoutedEventArgs e) //Plus
        {
            TextBlock1.Text += "+";
        }

        private void Button_Click_14(object sender, RoutedEventArgs e) //Minus
        {
            TextBlock1.Text += "-";
        }

        private void Button_Click_15(object sender, RoutedEventArgs e) //Multply
        {
            TextBlock1.Text += "*";
        }

        private void Button_Click_16(object sender, RoutedEventArgs e) //Divide
        {
            TextBlock1.Text += "/";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e) //Back space
        {
            string msg = TextBlock1.Text;
            TextBlock1.Text= msg.Substring(0, msg.Length - 1);
        }

        private void Button_Click_18(object sender, RoutedEventArgs e) //Clear screen
        {
            if (TextBlock1 != null)
            { 
                this.DataContext = Histroy.Record(i+1, TextBlock1.Text, TextBlock2.Text, OldItem);
            }
            TextBlock1.Text = "";
            TextBlock2.Text = "0";
        }
    }

    //public class Item : Base
    //{
    //    private string _title = string.Empty;
    //    public string Title
    //    {
    //        get { return _title; }
    //        set
    //        {
    //            Title = value;
    //            NotifyChange();
    //        }
    //    }
    //    private string _context = string.Empty;
    //    public string Context
    //    {
    //        get { return _context; }
    //        set
    //        {
    //            Context = value;
    //            NotifyChange();
    //        }
    //    }
    //}
    public class Item : Base
    {
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyChange();
            }
        }

        private string _content = string.Empty;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                NotifyChange();
            }
        }
        private string _color = "Black";
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }
    }
    public static class Histroy
    {
        public static ObservableCollection<Item> Record(int i, string str1,string str2, ObservableCollection<Item> Collection)
        {
            //var Collection = new ObservableCollection<Item>();
            if (i % 2 == 0)
            {
                Collection.Add(new Item
                {
                    Title = DateTime.Now.TimeOfDay.ToString().Remove(8),
                    Content = str1 + " = " + str2,
                    Color = "Gray"
                }
                    );
            }
            else
            {
                Collection.Add(new Item
                {
                    Title = DateTime.Now.TimeOfDay.ToString().Remove(8),
                    Content = str1 + " = " + str2,
                    Color = "Black"
                }
                    );
            }
                
            return Collection;
        }
    }
    public abstract class Base : INotifyPropertyChanged  
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChange([CallerMemberName]string property = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class Calculate
    {
        static public bool Error = false; 
        static public string Test(string a)
        {
            a += "Test";
            return a;
        }
        //static private double Calculater(string a) 
        //{
        //
        //}

        static public double Calculater1(string a) //将加减乘除分离，并进行加减计算
        {
            int y = 1;
            string[] str = a.Split('+', '-');
            double x = Calculater2(str[0]);
            for(int i=0;i<a.Length;i++)
            {
                if (a[i] == '+')
                {
                    x += Calculater2(str[y]);
                    y++;
                }
                else if (a[i] == '-')
                {
                    x -= Calculater2(str[y]);
                    y++;
                }
            }
            return x;
        }
        static private double Calculater2(string a) //乘除计算
        {
            int y = 1;
            string[] str = a.Split('*', '/');
            double x = double.Parse(str[0]);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '*')
                {
                    x *= double.Parse(str[y]);
                    y++;
                }
                else if (a[i] == '/')
                {
                    x /= double.Parse(str[y]);
                    y++;
                }
            }
            return x;
        }
    }
}
