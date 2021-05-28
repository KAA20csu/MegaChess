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
using Newtonsoft.Json;

namespace MegaChess.Desktop
{
    /// <summary>
    /// Логика взаимодействия для Continue.xaml
    /// </summary>
    public partial class Continue : Window
    {
        public Continue()
        {
            InitializeComponent();
            DirectoryInfo infoSaves = new DirectoryInfo("Saves");
            foreach(var c in infoSaves.GetFiles())
            {
                Label btnSave = new Label
                {
                    Content = c.Name.Trim(c.Extension.ToCharArray())
                };
                btnSave.MouseLeftButtonDown += BtnSave_Click;
                btnSave.HorizontalAlignment = HorizontalAlignment.Center;
                btnSave.VerticalAlignment = VerticalAlignment.Center;
                btnSave.FontSize = 30;

                listOfSaves.Children.Add(btnSave);
            }
            
        }

        private void BtnSave_Click(object sender, MouseButtonEventArgs e)
        {
            Label lab = sender as Label;
            var save = File.ReadAllText($"Saves/{lab.Content}.txt");
            string[] nicknames = lab.Content.ToString().Split("and");
            FirstPlayer.Name = nicknames[0];
            SecondPlayer.Name = nicknames[1];
            var jsonSaver = JsonConvert.DeserializeObject<FigureParams[,]>(save);
            Placement.field = jsonSaver;

            Game game = new Game();
            game.Show();
            Close();
        }
    }
}
