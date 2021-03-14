using System;
using System.Collections.Generic;
using System.Text;

namespace MegaChess.Logic
{
    public class MoveOfHeroes
    {
        private static int start_x;
        private static int end_X;
        private static int start_y;
        private static int end_Y;
        private static int horizontal;
        private static int vertical;
        public static int move_x = 0;
        public static int move_y = 0;
        private static int n = 0;

        public static bool MoveHorse()
        {

            if (horizontal == 1 && vertical == 2 || horizontal == 2 && vertical == 1)
            {
                return true;
            }

            return false;


        }
        public static bool MoveKing()
        {
            if (horizontal == 1 && vertical == 1 || horizontal == 0 && vertical == 1 || horizontal == 1 && vertical == 0)
            {
                return true;
            }
            return false;
        }
        public static bool MoveQueen()
        {
            if (horizontal == 0 && vertical > 0 || horizontal > 0 && vertical == 0 || horizontal != 0 && vertical != 0 && horizontal == vertical)
            {
                return true;
            }
            return false;
        }
        public static bool MoveCastle()
        {
            if (horizontal == vertical && vertical != 0 && horizontal != 0)
            {
                return true;
            }
            return false;
        }
        public static bool MoveElephant()
        {
            if (horizontal == 0 && vertical > 0 || horizontal > 0 && vertical == 0)
            {
                return true;
            }
            return false;
        }
        public static bool MovePawn()
        {
            if (start_y == 6 && start_y < 7)
            {
                if (horizontal == 0 && vertical == 2)
                {
                    return true;
                }
                
                else if (horizontal == 0 && vertical == 1)
                {
                    return true;
                }
                return false;

            }
            else if(start_y < 6)
            {
                if (horizontal == 0 && vertical == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public static void IfEnter(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {

                if (n == 0)
                {
                    start_x = move_x;
                    start_y = move_y;

                    n++;


                }
                else if (n == 1)
                {
                    end_X = move_x;
                    end_Y = move_y;

                    n = 0;

                    CheckMove();
                }

            }

        }
        public static void CheckMove()
        {
            if (Placement.field[start_y, start_x] != null)
            {
                horizontal = Math.Abs(start_x - end_X);
                vertical = Math.Abs(start_y - end_Y);

                MoveHero(Placement.field[start_y, start_x]);
            }
        }
        private static void MoveHero(string name)
        {

            bool b00l = false;

            switch (name)
            {
                case ("H"):
                    b00l = MoveOfHeroes.MoveHorse();
                    break;
                case ("K"):
                    b00l = MoveOfHeroes.MoveKing();
                    break;
                case ("Q"):
                    b00l = MoveOfHeroes.MoveQueen();
                    break;
                case ("C"):
                    b00l = MoveOfHeroes.MoveCastle();
                    break;
                case ("E"):
                    b00l = MoveOfHeroes.MoveElephant();
                    break;
                case ("P"):
                    b00l = MoveOfHeroes.MovePawn();
                    break;
            }

            if (b00l)
            {
                Placement.field[end_Y, end_X] = Placement.field[start_y, start_x];

                Placement.field[start_y, start_x] = null;
            }


        }
    }
}
