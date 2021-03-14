using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MegaChess.Logic
{
    public class Saves
    {
        public static void Saving(ConsoleKeyInfo key)
        {
            string text = "";

            if(key.Key == ConsoleKey.Escape)
            {
                foreach(string i in Placement.field)
                {
                    text += i + "\n";
                }
            }

            File.WriteAllText("save.txt", text);
        }
        public static void Dowing()
        {
            string[] array = File.ReadAllLines("save.txt");

            int num = 0;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(array[num].Length > 0)
                        Placement.field[i, j] = array[num];
                    num++;
                }
            }
        }
    }
}
