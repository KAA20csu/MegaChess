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
            string[] WinRate = File.ReadAllLines("Rate.txt");
            FirstWins.Content = WinRate[0];
            SecondWins.Content = WinRate[1];
        }

        private void GetWins()
        {
            
        }
    }
}
