using System;
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

        private readonly int X;
        private readonly int Y;
        public Brush OriginalBrush { get; set; }
        public Cell(int i, int j)
        {
            X = i;
            Y = j;
            
            isFilled = j % 2 == 0 ? i % 2 == 0 : i % 2 != 0;
            Square = new Label
            {
                Width = 75,
                Height = 75,
                Background = isFilled ? IDrawer.FirstBoardColor : IDrawer.SecondBoardColor
            };
            if (Placement.field[i, j] != null)
            {
                Square.Content = Placement.field[i, j].Name.ToString();
                Figure = Placement.field[i, j];
                if (Figure.Color == Logic.FigureColor.White) new FirstPlayer(Logic.FigureColor.White, 0);
                else if (Figure.Color == Logic.FigureColor.Black) new SecondPlayer(Logic.FigureColor.Black, 0);
            }

            Square.FontSize = 30;

            Square.MouseLeftButtonUp += PlayOnWho;
            
            OriginalBrush = Square.Background;
        }
        
        public static string FigureName = "";
        public void Moves()
        {
            Square.Content = IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Content;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Content = null;

            Figure = IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure = null;

            Placement.field[X, Y] = Placement.field[IDrawer.Row, IDrawer.Column];
            Placement.field[IDrawer.Row, IDrawer.Column] = null;

            IDrawer.Board[IDrawer.Row, IDrawer.Column].Square.Background
                = IDrawer.Board[IDrawer.Row, IDrawer.Column].isFilled ? IDrawer.FirstBoardColor : IDrawer.SecondBoardColor;
            IDrawer.Board[IDrawer.Row, IDrawer.Column].IsClicked = false;
        }
        public void PlayOnWho(object sender, MouseButtonEventArgs e)
        {
            if (IDrawer.WhiteOrBlack == true)
            {
                FigureClick(Logic.FigureColor.White, false);
            }
            else
            {
                FigureClick(Logic.FigureColor.Black, true);
            }
        }
        private string AttackedFigure { get; set; }
        private void FigureClick(Logic.FigureColor color, bool switcher)
        {
            if (!IDrawer.isClicked) // Если на самом поле выделенных ячеек нет, выполняем ветку с выделением.
            {
                if (Square.Content != null && Figure.Color == color) // Выделяем если есть фигура.
                {
                    Select();
                }
            }
            else if (IDrawer.isClicked) // Если на поле выделена клетка, выполняем эту ветку
            {
                if (Square.Content != null && IsClicked == true && Figure.Color == color) // Если на клетке есть фигура и она выделена
                {
                    FalseClick();
                }
                else if (Square.Content == null && IsClicked == false) // Если фигуры нет, и нет выделения
                {
                    MoveClick(switcher);
                }
                else if (Square.Content != null && IsClicked == false)
                {
                    KillClick(switcher);
                    if (Figure.Color == Logic.FigureColor.White)
                    {
                        WhiteKingKill();

                    }
                    else if (Figure.Color == Logic.FigureColor.Black)
                    {
                        BlackKingKill();
                    }
                    
                }
            }
        }
        private void Select()
        {
            Square.Background = Brushes.Red;
            IDrawer.isClicked = true; // Ставим два маркера, гласящих о том, что выделена клетка
            IsClicked = true;
            IDrawer.Row = X;
            IDrawer.Column = Y;
            MovementLogic.Xs.Add(Y);
            MovementLogic.Ys.Add(X);
            FigureName = Square.Content.ToString();
        }
        private void FalseClick()
        {
            Square.Background = OriginalBrush; // По клику красим обратно в тот же цвет
            IDrawer.isClicked = false; // Обнуляем параметры клика
            IsClicked = false;
            MovementLogic.Xs.Clear();
            MovementLogic.Ys.Clear();
        }
        private void MoveClick(bool switcher)
        {
            IDrawer.isClicked = false;

            MovementLogic.Xs.Add(Y);
            MovementLogic.Ys.Add(X);
            if (MovementLogic.CheckMove(MovementLogic.Xs, MovementLogic.Ys, FigureName, IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure.Color))
            {
                Moves();
                IDrawer.WhiteOrBlack = switcher;
            }
            else { MessageBox.Show("Некорректный ход, попробуйте ещё раз"); }
            MovementLogic.Xs.Clear();
            MovementLogic.Ys.Clear();
        }
        private void KillClick(bool switcher)
        {
            IDrawer.isClicked = false;
            AttackedFigure = Square.Content.ToString();
            MovementLogic.Xs.Add(Y);
            MovementLogic.Ys.Add(X);
            if(Figure.Color == Logic.FigureColor.White)
            {
                if (MovementLogic.CheckMove(MovementLogic.Xs, MovementLogic.Ys, FigureName, IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure.Color))
                {
                    Moves();
                }
            }
            else { MessageBox.Show("Некорректный ход, попробуйте ещё раз"); }
            if(Figure.Color == Logic.FigureColor.White)
            {
                if (MovementLogic.CheckMove(MovementLogic.Xs, MovementLogic.Ys, FigureName, IDrawer.Board[IDrawer.Row, IDrawer.Column].Figure.Color))
                {
                    Moves();
                }
            }
            else { MessageBox.Show("Некорректный ход, попробуйте ещё раз"); }
            MovementLogic.Xs.Clear();
            MovementLogic.Ys.Clear();
            IDrawer.WhiteOrBlack = switcher;
        }
        string[] RateArray { get; set; } = new string[] { };
        public static bool isFinished { get; set; }
        private void WhiteKingKill()
        {
            if (AttackedFigure == "K")
            {
                MessageBox.Show(@"Игра окончена, победил " + SecondPlayer.Name + "!");
                SecondPlayer.Wins++;
                isFinished = true;
                isFinished = true;
                RateArray = new string[] { FirstPlayer.Name, FirstPlayer.Wins.ToString(), SecondPlayer.Name, SecondPlayer.Wins.ToString() };
                File.WriteAllLines($"Rating/{FirstPlayer.Name} & {SecondPlayer.Name} rating.txt", RateArray);
            }
            
        }
        private void BlackKingKill()
        {
            if (AttackedFigure == "K")
            {
                MessageBox.Show("Игра окончена, победил " + FirstPlayer.Name + "!");
                FirstPlayer.Wins++;
                RateArray = new string[] { FirstPlayer.Name, FirstPlayer.Wins.ToString(), SecondPlayer.Name, SecondPlayer.Wins.ToString() };
                File.WriteAllLines($"Rating/{FirstPlayer.Name} & {SecondPlayer.Name} rating.txt", RateArray);

            }
        }
    }
}
