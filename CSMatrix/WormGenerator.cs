using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public class WormGenerator
    {
        private static Random random = new Random();
        private int maxSize;

        public WormGenerator(int maxSize)
        {
            this.maxSize = maxSize;
        }

        [Obsolete]
        public Worm Create()
        {
            int spaceSize;
            int charSize;
            SetSpaceAndCharSize(maxSize, out spaceSize, out charSize);

            char[] chars = new char[maxSize];
            for (int i = 0; i < maxSize; i++)
                chars[i] = GetRandomChar();

            return new Worm(spaceSize, charSize, chars);
        }

        public static Worm Create(int maxSize)
        {
            int spaceSize;
            int charSize;
            SetSpaceAndCharSize(maxSize, out spaceSize, out charSize);

            char[] chars = new char[maxSize];
            for (int i = 0; i < maxSize; i++)
                chars[i] = GetRandomChar();
            return new Worm(spaceSize, charSize, chars);
        }

        private static void SetSpaceAndCharSize(int maxSize, out int spaceSize, out int charSize)
        {
            /*// v1
            charSize = random.Next(5, maxSize - 5);
            spaceSize = random.Next(5, maxSize - charSize);*/

            /*// v2
            spaceSize = random.Next(5, maxSize);
            charSize = random.Next(0, maxSize - spaceSize);*/

            /*// v3
            spaceSize = random.Next(15, maxSize + 10);
            charSize = random.Next(5, maxSize);*/

            /*// v4
            spaceSize = random.Next(10, 30);
            charSize = random.Next(5, 20);*/

            /*// v5
            spaceSize = random.Next(20, maxSize + 20);
            charSize = random.Next(5, maxSize - 10);*/

            // v6
            spaceSize = random.Next(15, 20 + maxSize);
            charSize = random.Next(5, 20 + maxSize / 4);
        }


        private static char GetRandomChar()
        {
            if (random.Next(100) < 25) return (char)random.Next(33, 127);
            int numberOrCharProb = random.Next(100);
            if (numberOrCharProb < 33) return (char)random.Next(48, 58);
            else if (numberOrCharProb < 66) return (char)random.Next(65, 91);
            else return (char)random.Next(97, 123);
        }
    }
}
