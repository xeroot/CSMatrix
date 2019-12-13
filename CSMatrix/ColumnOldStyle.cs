using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public class ColumnOldStyle
    {
        private static Random random = new Random();
        private bool isCurrentWhite;
        public int length;

        public ColumnOldStyle()
        {
            //this.random = random;
            isCurrentWhite = true;
            length = GetRandomSpaceSize();
        }
        private int GetRandomSpaceSize()
        {
            //return random.Next(max * 20 / 100, max * 90 / 100);
            return random.Next(10, 50);
        }

        private int GetRandomCharSize()
        {
            //return random.Next(max * 20 / 100, max * 90 / 100);
            return random.Next(10, 20);
        }

        public char GetNextChar()
        {
            length--;
            if (length == -1)
            {
                isCurrentWhite = !isCurrentWhite;
                if (isCurrentWhite)
                    length = GetRandomSpaceSize();
                else length = GetRandomCharSize();
            }
            //return (char)(id + 48);
            if (isCurrentWhite) return ' ';
            return GetRandomChar();
        }
        private char GetRandomChar()
        {
            if (random.Next(100) < 25) return (char)random.Next(33, 127);
            int numberOrCharLetter = random.Next(100);
            if (numberOrCharLetter < 33) return (char)random.Next(48, 58);
            else if (numberOrCharLetter < 66) return (char)random.Next(65, 91);
            else return (char)random.Next(97, 123);
        }
    }
}
