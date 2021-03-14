using System;
using System.Collections.Generic;
using System.Text;

namespace MegaChess.Logic
{
    public class LogicOfMove
    {
            
            public static void Move(ConsoleKeyInfo key)
            {
                if (key.Key == ConsoleKey.UpArrow) MoveOfHeroes.move_y--;
                if (key.Key == ConsoleKey.DownArrow) MoveOfHeroes.move_y++;
                if (key.Key == ConsoleKey.LeftArrow) MoveOfHeroes.move_x--;
                if (key.Key == ConsoleKey.RightArrow) MoveOfHeroes.move_x++;

            }
            public static void Limits()
            {
                if (MoveOfHeroes.move_y < 0) MoveOfHeroes.move_y = 7;
                if (MoveOfHeroes.move_y > 7) MoveOfHeroes.move_y = 0;
                if (MoveOfHeroes.move_x < 0) MoveOfHeroes.move_x = 7;
                if (MoveOfHeroes.move_x > 7) MoveOfHeroes.move_x = 0;
            }

        }
    }

    

