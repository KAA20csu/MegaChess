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
using Newtonsoft.Json;
using MegaChess.Logic;
using System.IO;


namespace MegaChess.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            
        }
        private void btn_NewGame(object sender, RoutedEventArgs e)
        {

            Placement.Initialisation();
            
            Game game = new Game();
            game.Show();
            string[] rate = File.ReadAllLines("Rate.txt");
            FirstPlayer.Wins = int.Parse(rate[0]);
            SecondPlayer.Wins = int.Parse(rate[1]);
            this.Close();
            
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            var save = File.ReadAllText("save1.txt");
            var ds = JsonConvert.DeserializeObject<FigureParams[,]>(save);
            Placement.field = ds;
            
            Game game = new Game();
            game.Show();
            this.Close();
        }

        private void Rating_Click(object sender, RoutedEventArgs e)
        {
            Rating rating = new Rating();
            rating.Show();
        }
    }
    
}
