using System;
using System.Collections.Generic;
using System.Text;
namespace MegaChess.Logic
{
    public enum Names { K, Q, C, H, E, P }
    public enum FigureColor { White, Black }

    public class FigureParams // Объект самой фигуры
    {
       public Names Name { get; set; }
       public FigureColor Color { get; }

        public FigureParams(Names name, FigureColor color)
        {
            Name = name;
            Color = color;
        }
    }
    public class Placement
    {
        public static FigureParams[,] field { get; set; }
        public static void Initialisation()
        {
            field = new FigureParams[8, 8];
            field[7, 3] = new FigureParams(Names.K, FigureColor.Black);
            field[7, 4] = new FigureParams(Names.Q, FigureColor.Black);
            field[7, 0] = new FigureParams(Names.C, FigureColor.Black);
            field[7, 1] = new FigureParams(Names.H, FigureColor.Black);
            field[7, 2] = new FigureParams(Names.E, FigureColor.Black);
            field[7, 5] = new FigureParams(Names.E, FigureColor.Black);
            field[7, 6] = new FigureParams(Names.H, FigureColor.Black);
            field[7, 7] = new FigureParams(Names.C, FigureColor.Black);
            field[6, 0] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 1] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 2] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 3] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 4] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 5] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 6] = new FigureParams(Names.P, FigureColor.Black);
            field[6, 7] = new FigureParams(Names.P, FigureColor.Black);

            field[0, 3] = new FigureParams(Names.K, FigureColor.White);
            field[0, 4] = new FigureParams(Names.Q, FigureColor.White);
            field[0, 0] = new FigureParams(Names.C, FigureColor.White);
            field[0, 1] = new FigureParams(Names.H, FigureColor.White);
            field[0, 2] = new FigureParams(Names.E, FigureColor.White);
            field[0, 5] = new FigureParams(Names.E, FigureColor.White);
            field[0, 6] = new FigureParams(Names.H, FigureColor.White);
            field[0, 7] = new FigureParams(Names.C, FigureColor.White);
            field[1, 0] = new FigureParams(Names.P, FigureColor.White);
            field[1, 1] = new FigureParams(Names.P, FigureColor.White);
            field[1, 2] = new FigureParams(Names.P, FigureColor.White);
            field[1, 3] = new FigureParams(Names.P, FigureColor.White);
            field[1, 4] = new FigureParams(Names.P, FigureColor.White);
            field[1, 5] = new FigureParams(Names.P, FigureColor.White);
            field[1, 6] = new FigureParams(Names.P, FigureColor.White);
            field[1, 7] = new FigureParams(Names.P, FigureColor.White);
        }
        

    }
}
