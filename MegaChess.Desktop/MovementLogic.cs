using System;
using System.Collections.Generic;
using System.Text;
using MegaChess.Logic;

namespace MegaChess.Desktop
{
    public class MovementLogic
    {
        public static List<int> Xs = new List<int>();
        public static List<int> Ys = new List<int>();

        public static int DifX;
        public static int DifY;
        public static void CheckDifference(List<int> Xs, List<int> Ys)
        {
            DifX = Math.Abs(Xs[1] - Xs[0]);
            DifY = Math.Abs(Ys[1] - Ys[0]);
        }

        public static bool CheckMove(List<int> Xs, List<int> Ys, string figureName, MegaChess.Logic.FigureColor color)
        {
            CheckDifference(Xs, Ys);
            return figureName switch
            {
                ("H") => MoveHorse(DifX, DifY),
                ("K") => MoveKing(DifX, DifY),
                ("Q") => MoveQueen(DifX, DifY),
                ("C") => MoveCastle(DifX, DifY),
                ("E") => MoveElephant(DifX, DifY),
                ("P") => MovePawn(DifX, DifY, color),
                _ => false,
            };
        }
        public static bool MoveHorse(int DifX, int DifY)
        {

            if (DifX == 1 && DifY == 2 || DifX == 2 && DifY == 1)
            {
                return true;
            }
            return false;
        }
        public static bool MoveKing(int DifX, int DifY)
        {
            if (DifX == 1 && DifY == 1 || DifX == 0 && DifY == 1 || DifX == 1 && DifY == 0)
            {
                return true;
            }
            return false;
        }
        public static bool MoveQueen(int DifX, int DifY)
        {
            if (DifX == 0 && DifY > 0 || DifX > 0 && DifY == 0 || DifX != 0 && DifY != 0 && DifX == DifY)
            {
                return CheckCell(DifY, DifX);
            }
            return false;
        }
        public static bool MoveCastle(int DifX, int DifY)
        {
            if (DifX == 0 && DifY > 0 || DifX > 0 && DifY == 0)
            {
                return CheckCell(DifY, DifX);
            }
            return false;
        }
        public static bool MoveElephant(int DifX, int DifY)
        {
            if (DifY == DifX)
            {
                return CheckCell(DifY, DifX);
            }
            return false;
        }
        
        public static bool MovePawn(int DifX, int DifY, MegaChess.Logic.FigureColor color)
        {
            if(color == MegaChess.Logic.FigureColor.Black)
            {
                if(Ys[1] < Ys[0])
                {
                    if(Ys[0] == 6)
                    {
                        if (DifX == 0 && DifY == 2)
                        {
                            return true;
                        }

                        else if (DifX == 0 && DifY == 1)
                        {
                            return true;
                        }
                    }
                    else if (Ys[0] < 6)
                    {
                        if (DifX == 0 && DifY == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (Ys[1] > Ys[0])
                {
                    if (Ys[0] == 1)
                    {
                        if (DifX == 0 && DifY == 2)
                        {
                            return true;
                        }

                        else if (DifX == 0 && DifY == 1)
                        {
                            return true;
                        }
                    }
                    else if (Ys[0] > 1)
                    {
                        if (DifX == 0 && DifY == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        private static bool CheckCell(int DifY, int DifX)
        {
            if ((DifX == 1 && DifY == 0) || (DifX == 0 && DifY == 1) || (DifX == 1 && DifY == 1))
            {
                return true;
            }

            int i = Ys[0] + (DifY > 0 ? (Ys[0] > Ys[1] ? -1 : 1) : 0);
            int j = Xs[0] + (DifX > 0 ? (Xs[0] > Xs[1] ? -1 : 1) : 0);


            for (; DifY > 0 ? (Ys[0] > Ys[1] ? i > Ys[1] : i < Ys[1]) : DifX > 0 ? (Xs[0] > Xs[1] ? j > Xs[1] : j < Xs[1]) : 1 < 2;)
            {


                if (Placement.field[i, j] != null)
                {
                    return false;
                }


                i += (DifY > 0 ? (Ys[0] > Ys[1] ? -1 : 1) : 0);
                j += (DifX > 0 ? (Xs[0] > Xs[1] ? -1 : 1) : 0);

            }

            return true;
        }

    }
}
