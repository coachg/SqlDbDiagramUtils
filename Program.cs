using CommandLine;
using Dapper;
using DbDiagramUtils.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = ParseArgs(args);
            var command = CommandFactory.Produce(arguments);
            command.Perform();
            Console.WriteLine("Complete!!");
        }

        private static Args ParseArgs(string[] args)
        {
            var arguments = new Args();
            var parserSettings = new ParserSettings(true);
            var parser = new Parser(parserSettings);

            if (!parser.ParseArguments(args, arguments))
            {
                Console.WriteLine("Argument Parse Failure.");
                var parseErrors = "";
                if (arguments.LastParserState != null)
                {
                    foreach (var pe in arguments.LastParserState.Errors)
                        parseErrors += pe + Environment.NewLine;
                }
                throw new Exception("Error - could not parse arguments:" + parseErrors);
            }
            return arguments;
        }
    }

    public class Diagram
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public int version { get; set; }
        public byte[] definition { get; set; }
    }
}
