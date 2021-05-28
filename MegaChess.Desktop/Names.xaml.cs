using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Names.xaml
    /// </summary>
    public partial class Names : Window
    {
        public Names()
        {
            InitializeComponent();
        }

        private void NameClick(object sender, RoutedEventArgs e)
        {
            FirstPlayer.Name = FirstName.Text;
            SecondPlayer.Name = SecondName.Text;
            Game game = new Game();
            game.Show();
            this.Close();
        }
    }
}
