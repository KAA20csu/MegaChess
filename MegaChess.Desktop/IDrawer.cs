using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using MegaChess.Logic;
using MegaChess.Desktop;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;

namespace MegaChess.Desktop
{
    public class IDrawer
    {
        public static Cell[,] Board { get; private set; } = new Cell[8, 8]; // Массив из клеток, размера 8 на 8, как само поле
        public static bool isClicked { get; set; } = false; // Параметр для выделения ОБЩИЙ (маркер на самом поле, а не для отдельной клетки)
        public static int CountPlayerOne { get; set; } = 16;
        public static int CountPlayerTwo { get; set; } = 16;
        public static bool WhiteOrBlack { get; set; } = true;
        
        public static int Row;
        public static int Column;

        public  static string saveRate { get; set; } = "0";
        public static string saveRateSecond { get; set; } = "0";
        private static void TakeBoard() // Метод получения самой доски (заполнение)
        {

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Board[i, j] = new Cell(i,j); // Каждый элемент массива является клеткой (имеет все поля класса Cell)
                }
            }
        }
        public IDrawer()
        {
            TakeBoard();
        }
    }
    
}
