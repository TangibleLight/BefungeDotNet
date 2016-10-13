using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Befunge.Editor.CharStyles;

namespace Befunge.Editor.Controls
{
    public class CodeTextBox : RichTextBox
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(CodeTextBox), new PropertyMetadata(default(string), OnTextPropertyChanged));

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICharStyler TextStyler { get; set; }
    }
}