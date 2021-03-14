using System;
using System.Collections.Generic;
using System.Text;

namespace MegaChess.Logic
{
    public class Placement
    {
        public static string[,] field = new string[8, 8];
        public static void Initialisation()
        {
            field[7, 3] = "K";
            field[7, 4] = "Q";
            field[7, 0] = "C";
            field[7, 1] = "H";
            field[7, 2] = "E";
            field[7, 5] = "E";
            field[7, 6] = "H";
            field[7, 7] = "C";
            field[6, 0] = "P";
            field[6, 1] = "P";
            field[6, 2] = "P";
            field[6, 3] = "P";
            field[6, 4] = "P";
            field[6, 5] = "P";
            field[6, 6] = "P";
            field[6, 7] = "P";
        }

    }
}
