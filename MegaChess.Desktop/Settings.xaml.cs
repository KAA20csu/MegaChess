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

namespace MegaChess.Desktop
{
    public enum ColorsFirst { Aqua, Aquamarine, Blue, BlueViolet, Chartreuse, ConflowerBlue, DarkSlateBlue, DarkSeaGreen, Indigo, MediumPurple, Orchid, RoyalBlue, MediumVioletRed, Lime, SteelBlue }
    public enum ColorsSecond { AliceBlue, AntiqueWhite, Azure, Beige, Bisque, BlanchedAlmond, DarkGray, BurlyWood, Cornsilk, GhostWhite, Lavender, MintCream, Linen, WhiteSmoke}
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private string FirstColor { get; set; }
        private string SecondColor { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            firstColor.ItemsSource = Enum.GetValues(typeof(ColorsFirst));
            secondColor.ItemsSource = Enum.GetValues(typeof(ColorsSecond));
        }

        private void FirstColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirstColor = firstColor.SelectedItem.ToString();
        }

        private void SecondColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondColor = secondColor.SelectedItem.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("Properties/ColorProps.txt", FirstColor + "\n" + SecondColor);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
