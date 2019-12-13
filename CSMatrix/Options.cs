using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace CSMatrix
{
    public class Options : BaseAttribute
    {
        [Option('o', HelpText = "Use old-style scrolling")]
        public bool OldStyle { get; set; }

        [Option('u', Default = 4, HelpText = "Screen update delay (0 - 10)")]
        public int Delay { get; set; }

        [Option('C', Default = "green", HelpText = " Use this color for matrix")]
        public string Color { get; set; }

    }
}
