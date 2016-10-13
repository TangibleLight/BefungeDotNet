using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Befunge.Editor.CharStyles
{
    public interface ICharStyler
    {
        Run StyledString(string input);
    }
}
