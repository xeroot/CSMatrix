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
            if (isCurrentWhite) return ' ';
            return CharUtils.GetRandomChar();
        }
    }
}
