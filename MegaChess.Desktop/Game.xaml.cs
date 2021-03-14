using MegaChess.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
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
            InitializeComponent();
        }

        private bool isSelected;

        private bool isFilled;


        private void field_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(sender is Canvas canvas))
                throw new ArgumentException("Обработчик должен вызываться для Canvas", nameof(sender));

            canvas.Children.Clear();

            var cellSize = Math.Min(e.NewSize.Width, e.NewSize.Height) / 8;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    isFilled = j % 2 == 0 ? i % 2 == 0 : i % 2 != 0;


                    var cell = new Rectangle();

                    cell.Height = cellSize;
                    cell.Width = cellSize;
                    cell.Fill = isSelected
                    ? Brushes.Red
                    : isFilled ? Brushes.RosyBrown : Brushes.White;

                    cell.Stroke = Brushes.Black;
                    cell.StrokeThickness = 1;

                    canvas.Children.Add(cell);

                    Canvas.SetTop(cell, (i) * cellSize);
                    Canvas.SetLeft(cell, (j) * cellSize);

                    var text = new TextBox
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Background = null,
                        BorderBrush = null,
                        IsEnabled = false,
                        Width = cellSize,
                        Height = cellSize,
                        FontSize = 30,
                        IsHitTestVisible = false
                    };

                    if (string.IsNullOrWhiteSpace(Placement.field[i, j]))
                    {
                        text.Text = "";
                    }
                    else
                    {
                        text.Text = Placement.field[i, j];
                    }


                    canvas.Children.Add(text);

                    cell.MouseLeftButtonUp += Clicked;

                    Canvas.SetTop(text, (i) * cellSize);
                    Canvas.SetLeft(text, (j) * cellSize);


                }
            }
        }

        private Rectangle selectedRectangle;
        private Brush originalBrushSelectedRectangle;
        public void Clicked(object sender, MouseButtonEventArgs e)
        {

            isSelected = !isSelected;

            if (!(sender is Rectangle rectangle))
                throw new ArgumentException("Обработчик должен вызываться для Rectangle", nameof(sender));

            if (selectedRectangle != null)
                selectedRectangle.Fill = originalBrushSelectedRectangle;

            selectedRectangle = rectangle;
            originalBrushSelectedRectangle = selectedRectangle.Fill;

            rectangle.Fill = Brushes.LightGreen;
            
        }
    }
}
