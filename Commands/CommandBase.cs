using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDiagramUtils.Commands
{
    public abstract class CommandBase : ICommand
    {
        public Args Args { get; set; }

        public CommandBase(Args args)
        {
            Args = args;
        }

        public abstract void Perform();

        protected SqlConnection GetNewConnection()
        {
            return new SqlConnection($@"Server={Args.Server};Database={Args.Database};Trusted_Connection = True;");
        }
    }
}
