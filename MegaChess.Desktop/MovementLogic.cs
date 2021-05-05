using System;
using System.Collections.Generic;
using System.Text;

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

        public static bool CheckMove(List<int> Xs, List<int> Ys, string figureName)
        {
            CheckDifference(Xs, Ys);

            switch (figureName)
            {
                case ("H"):
                    return MoveHorse(DifX, DifY);
                case ("K"):
                    return MoveKing(DifX, DifY);
                case ("Q"):
                     return MoveQueen(DifX, DifY);
                case ("C"):
                    return MoveCastle(DifX, DifY);
                case ("E"):
                    return MoveElephant(DifX, DifY);
                case ("P"):
                    return MovePawn(DifX, DifY);
                default:
                    return false;
            }

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
                return true;
            }
            return false;
        }
        public static bool MoveCastle(int DifX, int DifY)
        {
            if (DifX == 0 && DifY > 0 || DifX > 0 && DifY == 0)
            {
                return true;
            }
            return false;
        }
        public static bool MoveElephant(int DifX, int DifY)
        {
            if (DifY == DifX)
            {
                return true;
            }
            return false;
        }
        public static bool MovePawn(int DifX, int DifY)
        {
            if (Ys[0] == 6 && Ys[0] < 7)
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

            return false;

        }
    }
}
