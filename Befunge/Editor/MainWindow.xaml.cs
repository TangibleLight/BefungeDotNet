using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Befunge.Editor.Annotations;
using Befunge.Editor.CharStyles;

namespace Befunge.Editor
{
    public class TextContext : INotifyPropertyChanged
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

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