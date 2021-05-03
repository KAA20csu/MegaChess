﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MegaChess.Logic;
using MegaChess.Desktop;

namespace MegaChess.Desktop
{
    public enum FigureColor { White, Black }

    public class Cell // Создаём клетку (ячейку) доски
    {
        private bool isFilled { get; set; } // Параметр окрашивания
        private bool IsClicked { get; set; } = false; // Параметр выделения
        private FigureParams Figure { get; set; }
        public Label Square { get; private set; } // Контрол для самой клетки
        private int X;
        private int Y;
        public static int _X;
        public static int _Y;
        private static string[] Colors = File.ReadAllLines("ColorProps.txt");

        public static SolidColorBrush FirstBoardColor = (SolidColorBrush)new BrushConverter().ConvertFromString(Colors[0]);
        public static SolidColorBrush SecondBoardColor = (SolidColorBrush)new BrushConverter().ConvertFromString(Colors[1]);
        public Brush OriginalBrush { get; set; }
        public Cell(int i, int j)
        {
            X = i;
            Y = j;
            _X = X;
            _Y = Y;
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
                else if (Figure.Color == Logic.FigureColor.Black) new SecondPlayer(Logic.FigureColor.Black, 16, 0);
            }
            Square.FontSize = 30;

            Square.MouseLeftButtonUp += field_MouseLeftButtonUp;
            
            OriginalBrush = Square.Background;
        }
        private string saveRate { get; set; }
        private string saveRateSecond { get; set; }
        
        private void CheckWin()
        {
            if (FirstPlayer.Count == 0 || SecondPlayer.Count == 0)
            {
                if (FirstPlayer.Count > SecondPlayer.Count)
                {
                    string winner = FirstPlayer.Name;
                    FirstPlayer.Wins++;
                    saveRate = FirstPlayer.Wins.ToString();
                    MessageBox.Show($"Игра окончена, победил {winner}");
                }
                else
                {
                    string winner = SecondPlayer.Name;
                    SecondPlayer.Wins++;
                    saveRateSecond = SecondPlayer.Wins.ToString();
                    MessageBox.Show($"Игра окончена, победил {winner}");
                }
                File.WriteAllText("Rate.txt", saveRate + "\n" + saveRateSecond);
            }
        }
        MovementLogic Logicc = new MovementLogic();
        public static string figureName = "";
        public void Moves()
        {
            //IDrawer drawer = new IDrawer();
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
        public void field_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                    MovementLogic.Xs.Add(Y);
                    MovementLogic.Ys.Add(X);
                    figureName = Square.Content.ToString();
                }
            }
            else if (IDrawer.isClicked) // Если на поле выделена клетка, выполняем эту ветку
            {
                if (Square.Content != null && IsClicked == true && Figure.Color == color) // Если на клетке есть фигура и она выделена
                {
                    Square.Background = OriginalBrush; // По клику красим обратно в тот же цвет
                    IDrawer.isClicked = false; // Обнуляем параметры клика
                    IsClicked = false;
                    MovementLogic.Xs.Clear();
                    MovementLogic.Ys.Clear();

                }
                else if (Square.Content == null && IsClicked == false) // Если фигуры нет, и нет выделения
                {
                    IDrawer.isClicked = false;

                    MovementLogic.Xs.Add(Y);
                    MovementLogic.Ys.Add(X);
                    if(MovementLogic.CheckMove(MovementLogic.Xs, MovementLogic.Ys, figureName))
                    {
                        Moves();
                    }
                    MovementLogic.Xs.Clear();
                    MovementLogic.Ys.Clear();

                    IDrawer.WhiteOrBlack = switcher;
                }
                else if (Square.Content != null && IsClicked == false)
                {
                    IDrawer.isClicked = false;

                    MovementLogic.Xs.Add(Y);
                    MovementLogic.Ys.Add(X);
                    if(MovementLogic.CheckMove(MovementLogic.Xs, MovementLogic.Ys, figureName))
                    {
                        Moves();
                    }

                    MovementLogic.Xs.Clear();
                    MovementLogic.Ys.Clear();
                    IDrawer.WhiteOrBlack = switcher;
                    if (Figure.Color == Logic.FigureColor.White) FirstPlayer.Count--;
                    else if (Figure.Color == Logic.FigureColor.Black) SecondPlayer.Count--;
                    CheckWin();
                }
            }
        }
    }
}
