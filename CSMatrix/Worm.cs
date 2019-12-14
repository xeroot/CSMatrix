using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public class Worm
    {
        public int Y { get; private set; }
        public int SpaceSize { get; private set; }
        public int CharSize { get; private set; }
        public char[] Chars { get; private set; }
        public int Size
        {
            get
            {
                return SpaceSize + CharSize;
            }
        }

        public Worm(int spaceSize, int charSize, char[] fullChars)
        {
            Y = 0;
            SpaceSize = spaceSize;
            CharSize = charSize;
            Chars = fullChars;
        }

        public void Move()
        {
            Y++;
        }
    }
}
