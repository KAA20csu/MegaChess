using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MegaChess.Logic;

namespace MegaChess.Desktop
{
    /// <summary>
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Window
    {
        public Rating()
        {
            InitializeComponent();

            DirectoryInfo infoRate = new DirectoryInfo("Rating");
            foreach (var c in infoRate.GetFiles())
            {
                string[] rate = File.ReadAllLines(c.FullName);
                Label lbRate = new Label(); 
                lbRate.Content = $"{rate[0]}: " + rate[1] + "\n" + $"{rate[2]}: " + rate[3];
                lbRate.FontSize = 30;
                lbRate.Foreground = Brushes.White;
                lbRate.HorizontalAlignment = HorizontalAlignment.Center;
                RateBoard.Children.Add(lbRate);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
