using System;
using System.Collections.Generic;
using System.Text;
using MegaChess.Logic;

namespace MegaChess.Logic
{
    public class FirstPlayer
    {
        public static string Name { get; set; }
        public FigureColor Figure { get; }
        public static int Wins { get; set; } 
        public FirstPlayer(FigureColor figure, int wins)
        {
            Figure = figure;
            Wins = wins;
        }
    }
    public class SecondPlayer
    {
        public static string Name { get; set; }
        public FigureColor Figure { get; }
        public static int Wins { get; set; } 
        public SecondPlayer(FigureColor figure, int wins)
        {
            Figure = figure;
            Wins = wins;
        }
    }

}
