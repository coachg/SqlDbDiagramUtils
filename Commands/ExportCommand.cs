using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils.Commands
{
    public class ExportCommand : CommandBase
    {
        public ExportCommand(Args args) : base(args)
        {

        }

        public override void Perform()
        {
            List<Diagram> diagrams;
            using (var connection = GetNewConnection())
            {
                diagrams = connection.Query<Diagram>($"SELECT * FROM dbo.sysdiagrams WHERE name = '{Args.Diagram}'").ToList();
            }

            if (diagrams == null || !diagrams.Any())
            {
                Console.WriteLine($"Could not find {Args.Diagram}");
                return;
            }

            var diagram = diagrams.First();
            File.WriteAllBytes(Args.Path, diagram.definition);  
        }
    }
}
