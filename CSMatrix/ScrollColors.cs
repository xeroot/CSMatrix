using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatrix
{
    public static class ScrollColors
    {
        public static readonly KeyValuePair<string, ConsoleColor> Default
            = new KeyValuePair<string, ConsoleColor>("green", ConsoleColor.DarkGreen);

        private static Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor>
            {
                {Default.Key,Default.Value},
                {"blue",ConsoleColor.DarkBlue},
                {"white",ConsoleColor.White},
                {"red",ConsoleColor.DarkRed}
            };

        public static ConsoleColor Parse(string colorStr)
        {
            if (colors.ContainsKey(colorStr.ToLower()))
                return colors[colorStr.ToLower()];
            else return Default.Value;
        }

    }
}
