using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Befunge.Editor.CharStyles
{
    public interface ITextStyler
    {
        IEnumerable<Run> StyledString(string input);
    }
}