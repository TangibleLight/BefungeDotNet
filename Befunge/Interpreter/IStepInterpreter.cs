using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Befunge.Interpreter
{
    public interface StepInterpreter : INotifyPropertyChanged
    {
        IVec2 InstructionPointerPosition { get; }
        string Output { get; }
        Func<string> InputRequest { get; set; }

        int? Step();
        int Run ();
    }
}