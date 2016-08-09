using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils.Commands
{
    public static class CommandFactory
    {
        public static ICommand Produce(Args args)
        {
            if (args.ExportDiagram)
            {
                return new ExportCommand(args);
            }
            else if (args.ImportDiagram)
            {
                return new ImportCommand(args);
            }

            throw new Exception("Could not determine command to run base on supplied arguments.");
        }
    }
}
