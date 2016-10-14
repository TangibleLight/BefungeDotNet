using System.Windows.Controls;
using System.Windows.Documents;
using Befunge.Editor.CharStyles;

namespace Befunge.Editor.Utils
{
    internal static class Extensions
    {
        public static void AppendStylizedText(this Paragraph p, ITextStyler styler, char text)
            => AppendStylizedText(p, styler, text.ToString());

        public static void AppendStylizedText(this Paragraph p, ITextStyler styler, string text)
            => p.Inlines.AddRange(styler?.StylizedString(text) ?? new[] {new Run(text)});
    }
}