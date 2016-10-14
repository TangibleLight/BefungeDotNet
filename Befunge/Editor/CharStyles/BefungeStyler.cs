using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Befunge.Editor.CharStyles
{
    public class BefungeStyler : ITextStyler
    {
        private string _directionals = "<>^v?r";

        public IEnumerable<Run> StyledString(string input)
        {
            var runs = new List<Run>();

            foreach (var c in input)
            {
                if (_directionals.Contains(c))
                    runs.Add(new Run(c.ToString())
                    {
                        Foreground = new SolidColorBrush(Colors.CornflowerBlue),
                        FontWeight = FontWeights.Bold
                    });
                else
                {
                    runs.Add(new Run(c.ToString())
                    {
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontWeight = FontWeights.Normal
                    });
                }
            }

            return runs;
        }
    }
}