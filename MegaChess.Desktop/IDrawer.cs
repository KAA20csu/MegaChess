using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using MegaChess.Logic;
using MegaChess.Desktop;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;

namespace MegaChess.Desktop
{
    class IDrawer
    {
        public static Cell[,] Board { get; private set; } = new Cell[8, 8]; // Массив из клеток, размера 8 на 8, как само поле
        public static bool isClicked { get; set; } = false; // Параметр для выделения ОБЩИЙ (маркер на самом поле, а не для отдельной клетки)
        public static int CountPlayerOne { get; set; } = 16;
        public static int CountPlayerTwo { get; set; } = 16;
        public static bool WhiteOrBlack { get; set; } = true;
        
        public static int Row;
        public static int Column;
        private void TakeBoard() // Метод получения самой доски (заполнение)
        {

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Board[i, j] = new Cell(i,j); // Каждый элемент массива является клеткой (имеет все поля класса Cell)
                }
            }
        }
        public IDrawer()
        {
            TakeBoard();
        }
    }
    public enum FigureColor { White, Black }
    
    public class Cell // Создаём клетку (ячейку) доски
    {
        private bool isFilled { get; set; } // Параметр окрашивания
        private bool IsClicked { get; set; } = false; // Параметр выделения
        private FigureParams Figure { get; set; }
        public Label Square { get; private set; } // Контрол для самой клетки
        private int X;
        private int Y;
        private static string[] Colors = File.ReadAllLines("ColorProps.txt");

        SolidColorBrush FirstBoardColor = (SolidColorBrush)new BrushConverter().ConvertFromString(Colors[0]);
        SolidColorBrush SecondBoardColor = (SolidColorBrush)new BrushConverter().ConvertFromString(Colors[1]);
        
        public Cell(int i, int j)
        {
            
            X = i;
            Y = j;
            isFilled = j % 2 == 0 ? i % 2 == 0 : i % 2 != 0; // Формула покраски клеток
            Square = new Label(); // Инициализируем клетку, задаём размер, красим
            Square.Width = 75;
            Square.Height = 75;
            Square.Background = isFilled ? FirstBoardColor : SecondBoardColor;
            if (Placement.field[i, j] != null) 
            {
                Square.Content = Placement.field[i, j].Name.ToString();
                Figure = Placement.field[i, j];
                if (Figure.Color == Logic.FigureColor.White) new FirstPlayer(Logic.FigureColor.White, 16, 0);
                else if(Figure.Color == Logic.FigureColor.Black) new SecondPlayer(Logic.FigureColor.Black, 16, 0);
            }
            Square.FontSize = 30;
            
            Square.MouseLeftButtonUp += field_MouseLeftButtonUp;
            orig = Square.Background;
        }
        public Brush orig { get; }

        private static List<int> Xs = new List<int>();
        private static List<int> Ys = new List<int>();
        public static string figureName = "";
        private void field_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IDrawer.WhiteOrBlack == true)
            {
                PlayWithWho(Logic.FigureColor.White, false);
            }
            else
            {
                PlayWithWho(Logic.FigureColor.Black, true);
            }
        }
        private void PlayWithWho(Logic.FigureColor color, bool switcher)
        {
            if (!IDrawer.isClicked) // Если на самом поле выделенных ячеек нет, выполняем ветку с выделением.
            {
                if (Square.Content != null && Figure.Color == color) // Выделяем если есть фигура.
                {

                    Square.Background = Brushes.Red;
                    IDrawer.isClicked = true; // Ставим два маркера, гласящих о том, что выделена клетка
                    IsClicked = true;
                    IDrawer.Row = X;
                    IDrawer.Column = Y;
                    Xs.Add(Y);
                    Ys.Add(X);
                    figureName = Square.Content.ToString();
                }
            }
            else if (IDrawer.isClicked) // Если на поле выделена клетка, выполняем эту ветку
            {
                if (Square.Content != null && IsClicked == true && Figure.Color == color) // Если на клетке есть фигура и она выделена
                {
                    Square.Background = orig; // По клику красим обратно в тот же цвет
                    IDrawer.isClicked = false; // Обнуляем параметры клика
                    IsClicked = false;
                    Xs.Clear();
                    Ys.Clear();

                }
                else if (Square.Content == null && IsClicked == false) // Если фигуры нет, и нет выделения
                {
                    IDrawer.isClicked = false;

                    Xs.Add(Y);
                    Ys.Add(X);

                    CheckDifference(Xs, Ys);
                    CheckMove(DifX, DifY, figureName);
                    Xs.Clear();
                    Ys.Clear();

                    IDrawer.WhiteOrBlack = switcher;
                }
                else if (Square.Content != null && IsClicked == false)
                {
                    IDrawer.isClicked = false;

                    Xs.Add(Y);
                    Ys.Add(X);
                    CheckDifference(Xs, Ys);
                    CheckMove(DifX, DifY, figureName);

                    Xs.Clear();
                    Ys.Clear();
                    IDrawer.WhiteOrBlack = switcher;
                    if (Figure.Color == Logic.FigureColor.White) FirstPlayer.Count--;
                    else if (Figure.Color == Logic.FigureColor.Black) SecondPlayer.Count--;
                    CheckWin();
                }
                
            }
        }
        private void CheckWin()
        {
            if (FirstPlayer.Count == 0 || SecondPlayer.Count == 0)
            {
                if (FirstPlayer.Count > SecondPlayer.Count)
                {
                    string winner = FirstPlayer.Name;
                    MessageBox.Show($"Игра окончена, победил {winner}");
                }
                else 
                {
                    string winner = SecondPlayer.Name;
                    MessageBox.Show($"Игра окончена, победил {winner}");
                }
            }
        }
        private int DifX;
        private int DifY;
        private void CheckDifference(List<int> Xs, List<int> Ys)
        {
            DifX = Math.Abs(Xs[1] - Xs[0]);
            DifY = Math.Abs(Ys[1] - Ys[0]);
        }

        private void Move()
        {
            Square.Content = IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Content;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Content = null;

            Figure = IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure = null;

            Placement.field[X, Y] = Placement.field[IDrawer.Row, IDrawer.Column];
            Placement.field[IDrawer.Row, IDrawer.Column] = null;

            IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Background
                = IDrawer.Board[IDrawer.Row, IDrawer.Column].isFilled ? FirstBoardColor : SecondBoardColor;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].IsClicked = false;

            
        }

        private void CheckMove(int DifX, int DifY, string figureName)
        {
            switch (figureName)
            {
                case ("H"):
                    MoveHorse();
                    break;
                case ("K"):
                    MoveKing();
                    break;
                case ("Q"):
                    MoveQueen();
                    break;
                case ("C"):
                    MoveCastle();
                    break;
                case ("E"):
                    MoveElephant();
                    break;
                case ("P"):
                    MovePawn();
                    break;
            }
        }

        public void MoveHorse()
        {

            if (DifX == 1 && DifY == 2 || DifX == 2 && DifY == 1)
            {
                Move();
            }

        }
        public void MoveKing()
        {
            if (DifX == 1 && DifY == 1 || DifX == 0 && DifY == 1 || DifX == 1 && DifY == 0)
            {
                Move();
            }

        }
        public void MoveQueen()
        {
            if (DifX == 0 && DifY > 0 || DifX > 0 && DifY == 0 || DifX != 0 && DifY != 0 && DifX == DifY)
            {
                Move();
            }

        }
        public void MoveCastle()
        {
            if (DifX == 0 && DifY > 0 || DifX > 0 && DifY == 0)
            {
                Move();
            }

        }
        public void MoveElephant()
        {
            if (DifY == DifX)
            {
                Move();
            }

        }
        public void MovePawn()
        {
            if (Ys[0] == 6 && Ys[0] < 7)
            {
                if (DifX == 0 && DifY == 2)
                {
                    Move();
                }

                else if (DifX == 0 && DifY == 1)
                {
                    Move();
                }


            }
            else if (Ys[0] < 6)
            {
                if (DifX == 0 && DifY == 1)
                {
                    Move();
                }
            }

        }
    }
}
