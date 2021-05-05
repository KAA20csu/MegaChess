using System;
using System.Collections.Generic;
using System.Text;
using MegaChess.Logic;

namespace MegaChess.Logic
{
    public class FirstPlayer
    {
        public static string Name { get; private set; } = "First Player";
        public FigureColor Figure { get; }
        public static int Count { get; set; }
        public static int Wins { get; set; } 
        public FirstPlayer(FigureColor figure, int count, int wins)
        {
            Figure = figure;
            Count = count;
            Wins = wins;
        }
    }
    public class SecondPlayer
    {
        public static string Name { get; private set; } = "Second Player";
        public FigureColor Figure { get; }
        public static int Count { get; set; }
        public static int Wins { get; set; } 
        public SecondPlayer(FigureColor figure, int count, int wins)
        {
            Figure = figure;
            Count = count;
            Wins = wins;
        }
    }

}
