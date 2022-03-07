using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Jokemon
{
    static class MapReader
    {
        public static int MapSize { get; set; }

        public static char[,] tileArray = new char[MapSize, MapSize];

        public static char[,] ReadFile(string inFileName)
        {
            StreamReader sRead = new StreamReader(inFileName + ".txt");
            string line = "";
            int counter = 0;

            do
            {
                line = sRead.ReadLine();

                for (int i = 0; i < line.Length; i++)
                {
                    tileArray[counter, i] = line[i];
                }

                if (counter < line.Length - 1)
                {
                    counter++;
                }

            } while (!sRead.EndOfStream);

            sRead.Close();
            return tileArray;
        }
    }
}
