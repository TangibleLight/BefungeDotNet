using System.ComponentModel;
using System.Data.SqlTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Befunge.Editor.CharStyles;
using Befunge.Editor.Utils;

namespace Befunge.Editor.Controls
{
    public class CodeTextBox : RichTextBox
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(CodeTextBox),
            new PropertyMetadata(default(string), OnTextPropertyChanged));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                UpdateColors();
            }
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctb = d as CodeTextBox;
            var val = e.NewValue as string;

            if (ctb == null) return;
            var start = ctb.Document.ContentStart;
            var end = ctb.Document.ContentEnd;
            var range = new TextRange(start, end);
            range.Text = val + "\r\n";
        }

        public ITextStyler TextStyler { get; set; }
        private bool _changingColors;

        public CodeTextBox()
        {
            var s = new Style {TargetType = typeof(Paragraph)};
            s.Setters.Add(new Setter(Block.MarginProperty, new Thickness(0)));
            Resources.Add(typeof(Paragraph), s);

            FontFamily = new FontFamily("Consolas");
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            UpdateColors();
        }

        public void UpdateColors()
        {
            if (_changingColors) return;
            _changingColors = true;

            var start = Document.ContentStart;
            var caret = CaretPosition;
            var end = Document.ContentEnd;

            var before = new TextRange(start, caret);
            var after = new TextRange(caret, end);

            var beforeText = before.Text.Replace("\r\n", "\n");
            var afterText = after.Text.Replace("\r\n", "\n");
            if (afterText.Length > 0)
                afterText = afterText.Substring(0, afterText.Length - 1);
            var allText = beforeText + afterText;

            Text = allText;

            Document.Blocks.Clear();

            var p = new Paragraph();
            Document.Blocks.Add(p);

            p.AppendStylizedText(TextStyler, beforeText);
            CaretPosition = p.ContentEnd;
            p.AppendStylizedText(TextStyler, afterText);

            _changingColors = false;
        }
    }
}