using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public class ColumnNewStyle
    {
        public int X;
        public int fullSize;
        private List<Worm> worms;
        private char[] chars;

        public ColumnNewStyle(int XPos, int size)
        {
            X = XPos;
            fullSize = size;
            chars = new char[size];
            worms = new List<Worm>
            {
                WormGenerator.Create(fullSize)
            }; 

            for (int i = 0; i < size; i++)
                chars[i] = ' ';
        }

        //int counter = 0;
        public void Scroll()
        {
            foreach (var worm in worms)
                worm.Move();

            var lastWorm = worms.Last();
            if (lastWorm.Y >= lastWorm.Size)
                worms.Add(WormGenerator.Create(fullSize));

            var firstWorm = worms.First();
            if (firstWorm.Y >= firstWorm.Size + fullSize)
                worms.Remove(firstWorm);

            RefreshChars();
        }

        private void RefreshChars()
        {
            foreach (var worm in worms)
            {
                // TODO: improve this :/
                for (int i = 0; i < worm.Size; i++)
                {
                    if (worm.Y - i <= 0) continue;
                    if (worm.Y - i > 0 && worm.Y - i < fullSize)
                    {
                        if (i < worm.SpaceSize) chars[worm.Y - i] = ' ';
                        else chars[worm.Y - i] = worm.Chars[worm.Y - i];
                    }
                }
            }
        }

        public char GetChar(int YPos)
        {
            return chars[YPos];
        }

    }
}
