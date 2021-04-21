using System;
using System.Collections.Generic;
using System.Text;


namespace MegaChess.Logic
{
    public enum NameFigure { K, Q, C, H, E, P }
    public enum FigureColor { White, Black }

    public class FigureParams
    {
       public NameFigure Name { get;}
       public FigureColor Color { get; }

        public FigureParams(NameFigure figure, FigureColor color)
        {
            Name = figure;
            Color = color;
        }
    }
    public class Placement
    {
        public static FigureParams[,] field = new FigureParams[8, 8];
        public static void Initialisation()
        {
            field[7, 3] = new FigureParams(NameFigure.K, FigureColor.Black);
            field[7, 4] = new FigureParams(NameFigure.Q, FigureColor.Black);
            field[7, 0] = new FigureParams(NameFigure.C, FigureColor.Black);
            field[7, 1] = new FigureParams(NameFigure.H, FigureColor.Black);
            field[7, 2] = new FigureParams(NameFigure.E, FigureColor.Black);
            field[7, 5] = new FigureParams(NameFigure.E, FigureColor.Black);
            field[7, 6] = new FigureParams(NameFigure.H, FigureColor.Black);
            field[7, 7] = new FigureParams(NameFigure.C, FigureColor.Black);
            field[6, 0] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 1] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 2] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 3] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 4] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 5] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 6] = new FigureParams(NameFigure.P, FigureColor.Black);
            field[6, 7] = new FigureParams(NameFigure.P, FigureColor.Black);

            field[0, 3] = new FigureParams(NameFigure.K, FigureColor.White);
            field[0, 4] = new FigureParams(NameFigure.Q, FigureColor.White);
            field[0, 0] = new FigureParams(NameFigure.C, FigureColor.White);
            field[0, 1] = new FigureParams(NameFigure.H, FigureColor.White);
            field[0, 2] = new FigureParams(NameFigure.E, FigureColor.White);
            field[0, 5] = new FigureParams(NameFigure.E, FigureColor.White);
            field[0, 6] = new FigureParams(NameFigure.H, FigureColor.White);
            field[0, 7] = new FigureParams(NameFigure.C, FigureColor.White);
            field[1, 0] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 1] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 2] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 3] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 4] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 5] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 6] = new FigureParams(NameFigure.P, FigureColor.White);
            field[1, 7] = new FigureParams(NameFigure.P, FigureColor.White);
        }
        

    }
}
