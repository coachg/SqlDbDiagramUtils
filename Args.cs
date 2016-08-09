using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils
{
    public class Args
    {
        [Option("ExportDiagram", Required = false, HelpText = "Command to export a database diagram to a file.")]
        public bool ExportDiagram { get; set; }

        [Option("ImportDiagram", Required = false, HelpText = "Command to import a database diagram to a file.")]
        public bool ImportDiagram { get; set; }

        [Option('S', "server", Required = true, HelpText = "The name of the database server.")]
        public string Server { get; set; }

        [Option('D', "database", Required = true, HelpText = "The name of the database.")]
        public string Database { get; set; }

        [Option('M', "diagram", Required = true, HelpText = "The name of the diagram.")]
        public string Diagram { get; set; }

        [Option('P', "path", Required = true, HelpText = "The file path to the export/import file.")]
        public string Path { get; set; }


        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

    }
}
