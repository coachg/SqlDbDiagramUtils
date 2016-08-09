using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils.Commands
{
    public interface ICommand
    {
        Args Args { get; set; }
        void Perform();
    }
}
