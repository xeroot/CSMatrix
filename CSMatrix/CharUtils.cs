using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public static class CharUtils
    {
        private static readonly Random random = new Random();

        public static char GetRandomChar()
        {
            if (random.Next(100) < 25) return (char)random.Next(33, 127);
            int numberOrCharProb = random.Next(100);
            if (numberOrCharProb < 33) return (char)random.Next(48, 58);
            else if (numberOrCharProb < 66) return (char)random.Next(65, 91);
            else return (char)random.Next(97, 123);
        }

        public static int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
