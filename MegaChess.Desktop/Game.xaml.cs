using MegaChess.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MegaChess.Desktop
{

    public partial class Game : Window
    {

        public Game()
        {
            Placement.Initialisation();
            new IDrawer(); // Добавляем конструктор в Code Behind, чтобы дальше работать с доской.
            
            InitializeComponent();
        }
        private void field_SizeChanged(object sender, SizeChangedEventArgs e) // Создаём обработчик события для Canvas, чтобы отрисовать доску.
        {
            field.Children.Clear();

            for(int i = 0; i < 8; i ++)
            {
                for(int j = 0; j < 8; j++)
                {
                    field.Children.Add(IDrawer.Board[i, j].Square); // Дoбавляем на Canvas элементы массива с клетками (уже закрашенными и с установленным размером для каждой).

                    Canvas.SetTop(IDrawer.Board[i, j].Square, 75 * i); // Устанавливаем позицию на Canvas.
                    Canvas.SetLeft(IDrawer.Board[i, j].Square, 75 * j);
                }
            }
        }
    }
}
