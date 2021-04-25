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
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    /// 
    public enum ColorsFirst { Yellow, Green, Blue }
    public enum ColorsSecond { White, Orange, Grey}
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

        private void firstColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirstColor = firstColor.SelectedItem.ToString();
        }

        private void secondColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondColor = secondColor.SelectedItem.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("ColorProps.txt", FirstColor + "\n" + SecondColor);
            this.Close();
        }
    }
}
