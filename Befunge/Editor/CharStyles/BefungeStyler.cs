using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Befunge.Editor.CharStyles
{
    public class BefungeStyler : ITextStyler
    {
        public TextStyle DefaultStyle { get; set; } = new TextStyle();

        public TextStyle OperatorStyle { get; set; } = new TextStyle(Colors.IndianRed, FontWeights.Bold);
        public TextStyle StackOpStyle { get; set; } = new TextStyle(Colors.IndianRed, FontWeights.Bold);
        public TextStyle CompareStyle { get; set; } = new TextStyle(Colors.CornflowerBlue, FontWeights.Bold);
        public TextStyle IfStyle { get; set; } = new TextStyle(Colors.CornflowerBlue, FontWeights.Bold);
        public TextStyle IoStyle { get; set; } = new TextStyle(Colors.SeaGreen, FontWeights.Bold);
        public TextStyle IpStyle { get; set; } = new TextStyle(Colors.DarkGoldenrod, FontWeights.Bold);
        public TextStyle LiteralStyle { get; set; } = new TextStyle(Colors.Black, FontWeights.Bold);
        public TextStyle SourceModStyle { get; set; } = new TextStyle(Colors.SeaGreen, FontWeights.Bold);
        public TextStyle TrampStyle { get; set; } = new TextStyle(Colors.Plum, FontWeights.Bold);
        public TextStyle DirectionalStyle { get; set; } = new TextStyle(Colors.CornflowerBlue, FontWeights.Bold);
        public TextStyle EndStyle { get; set; } = new TextStyle(Colors.OrangeRed, FontWeights.Bold);

        private const string Operators = "!%*+-/";
        private const string StackOps = "\\:$n";
        private const string Compares = "`w";
        private const string Ifs = "|_";
        private const string Ios = ",.&~";
        private const string Ips = "\"";
        private const string Literals = "0123456789abcdef";
        private const string SourceMods = "gp";
        private const string Tramps = "#;";
        private const string Directionals = "<>^v[]r?";
        private const string Ends = "@";

        private TextStyle GetStyle(char c)
        {
            if (Operators.Contains(c)) return OperatorStyle;
            if (StackOps.Contains(c)) return StackOpStyle;
            if (Compares.Contains(c)) return CompareStyle;
            if (Ifs.Contains(c)) return IfStyle;
            if (Ios.Contains(c)) return IoStyle;
            if (Ips.Contains(c)) return IpStyle;
            if (Literals.Contains(c)) return LiteralStyle;
            if (SourceMods.Contains(c)) return SourceModStyle;
            if (Tramps.Contains(c)) return TrampStyle;
            if (Directionals.Contains(c)) return DirectionalStyle;
            if (Ends.Contains(c)) return EndStyle;
            return DefaultStyle;
        }

        public IEnumerable<Run> StylizedString(string input) => input.Select(c => GetStyle(c).Stylize(c.ToString()));
    }
}