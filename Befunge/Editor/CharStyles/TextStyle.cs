using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Befunge.Editor.CharStyles
{
    public class TextStyle
    {
        public Brush Foreground { get; set; }
        public Brush Background { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStyle FontStyle { get; set; }

        #region Constructors

        public TextStyle()
        {
        }

        #region Brushes

        public TextStyle(Brush foreground)
        {
            Foreground = foreground;
        }

        public TextStyle(Brush foreground, FontWeight fontWeight)
        {
            Foreground = foreground;
            FontWeight = fontWeight;
        }

        public TextStyle(Brush foreground, FontWeight fontWeight, FontStyle fontStyle)
        {
            Foreground = foreground;
            FontWeight = fontWeight;
            FontStyle = fontStyle;
        }

        public TextStyle(Brush foreground, FontWeight fontWeight, FontStyle fontStyle, Brush background)
        {
            Foreground = foreground;
            Background = background;
            FontWeight = fontWeight;
            FontStyle = fontStyle;
        }

        #endregion

        #region Colors

        public TextStyle(Color foreground)
        {
            Foreground = new SolidColorBrush(foreground);
        }

        public TextStyle(Color foreground, FontWeight fontWeight)
        {
            Foreground = new SolidColorBrush(foreground);
            FontWeight = fontWeight;
        }

        public TextStyle(Color foreground, FontWeight fontWeight, FontStyle fontStyle)
        {
            Foreground = new SolidColorBrush(foreground);
            FontWeight = fontWeight;
            FontStyle = fontStyle;
        }

        public TextStyle(Color foreground, FontWeight fontWeight, FontStyle fontStyle, Color background)
        {
            Foreground = new SolidColorBrush(foreground);
            Background = new SolidColorBrush(background);
            FontWeight = fontWeight;
            FontStyle = fontStyle;
        }

        #endregion

        #endregion

        public Run Stylize(string text)
        {
            var run = new Run(text)
            {
                FontWeight = FontWeight,
                FontStyle = FontStyle
            };
            if (Foreground != null) run.Foreground = Foreground;
            if (Background != null) run.Background = Background;

            return run;
        }
    }
}