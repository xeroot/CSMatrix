using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using CommandLine;
using CommandLine.Text;

namespace CSMatrix
{
    class Program
    {
        private static int WIDTH = Console.WindowWidth - 1;
        private static int HEIGHT = Console.WindowHeight - 1;
        private static bool exitPressed = false;
        private static string[] lines = new string[HEIGHT];
        private static ColumnOldStyle[] oldStyleColumns = new ColumnOldStyle[WIDTH];
        private static ColumnNewStyle[] newStyleColumns = new ColumnNewStyle[WIDTH];
        private static ScrollStyle scrollStyle = ScrollStyle.NewStyle;
        private static int delayLevel = 4;
        private static int delay = 10 * delayLevel;

        static void Main(string[] args)
        {
            HideCursor();
            ParseArguments(args);
            StartAsync();
            ExitIfQPressed();
        }

        private static void HideCursor()
        {
            Console.CursorVisible = false;
        }

        private static void ParseArguments(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(option =>
                {
                    if (option.OldStyle) scrollStyle = ScrollStyle.OldStyle;
                    if (option.Delay != delayLevel)
                    {
                        if (option.Delay <= 10 || option.Delay >= 1)
                        {
                            delayLevel = option.Delay;
                            delay = 10 * delayLevel;
                        }
                    }
                    if (option.Color.ToLower() != ScrollColors.Default.Key)
                        Console.ForegroundColor = ScrollColors.Parse(option.Color);
                    else Console.ForegroundColor = ScrollColors.Default.Value;
                })
                .WithNotParsed<Options>(option =>
                {
                    ResetShell();
                    Environment.Exit(0);
                });
        }

        private static void ExitIfQPressed()
        {
            var key = ConsoleKey.NoName;
            while (!key.Equals(ConsoleKey.Q))
                key = Console.ReadKey(true).Key;
            exitPressed = true;
            Thread.Sleep(50);
            Console.Clear();
            ResetShell();
        }

        private static void ResetShell()
        {
            Console.ResetColor();
            Console.CursorVisible = true;
        }

        private static async void StartAsync()
        {
            RefreshSizeAndColumns();
            while (!exitPressed)
            {
                if (scrollStyle == ScrollStyle.NewStyle)
                    ScrollNewStyleColumns();
                else
                    ScrollOldStyleColumns();
                PrintLines();
                if (IsSizeChanged()) RefreshSizeAndColumns();
                await Task.Delay(delay); //70 is the slowest in unix shell
            }
            Console.Clear();
        }

        private static void PrintLines()
        {
            Console.SetCursorPosition(0, 0);
            foreach (var line in lines)
                Console.WriteLine(line);
        }

        private static void ScrollNewStyleColumns()
        {
            foreach (var column in newStyleColumns)
                column.Scroll();

            for (int i = 0; i < HEIGHT; i++)
            {
                string newLine = string.Empty;
                for (int j = 0; j < WIDTH; j++)
                    newLine += newStyleColumns[j].GetChar(i);
                lines[i] = newLine;
            }
        }

        private static void ScrollOldStyleColumns()
        {
            for (int i = lines.Length - 1; i >= 1; i--)
                lines[i] = lines[i - 1];

            string newLine = string.Empty;
            foreach (var column in oldStyleColumns)
                newLine += column.GetNextChar();
            lines[0] = newLine;
        }

        private static bool IsSizeChanged()
        {
            return HEIGHT != Console.WindowHeight - 1
                || WIDTH != Console.WindowWidth - 1;
        }

        private static void RefreshSizeAndColumns()
        {
            Console.Clear();
            HEIGHT = Console.WindowHeight - 1;
            WIDTH = Console.WindowWidth - 1;
            RefreshColumns();
        }

        private static void RefreshColumns()
        {
            if (scrollStyle == ScrollStyle.NewStyle)
                RefreshNewStyleColumns();
            else RefreshOldStyleColumns();
        }

        private static void RefreshNewStyleColumns()
        {
            CleanLines();
            newStyleColumns = new ColumnNewStyle[WIDTH];
            for (int i = 0; i < WIDTH; i++)
                newStyleColumns[i] = new ColumnNewStyle(i, HEIGHT);
        }

        private static void RefreshOldStyleColumns()
        {
            CleanLines();
            oldStyleColumns = new ColumnOldStyle[WIDTH];
            for (int i = 0; i < WIDTH; i++)
                oldStyleColumns[i] = new ColumnOldStyle();
        }

        private static void CleanLines()
        {
            lines = new string[HEIGHT];
            for (int i = 0; i < lines.Length; i++)
                lines[i] = new string(' ', WIDTH);
        }
    }
}
