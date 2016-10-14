using System.Windows;
using Befunge.Editor.CharStyles;

namespace Befunge.Editor
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            EditRegion.TextStyler = new BefungeStyler();
            EditRegion.UpdateColors();
        }
    }
}