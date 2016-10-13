using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Befunge.Interpreter
{
    public interface IVec2 : INotifyPropertyChanged
    {
        int X { get; set; }
        int Y { get; set; }

        int ToIndex(string text);
        void FromIndex(string text, int i);
    }
}