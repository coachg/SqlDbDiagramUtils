using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DbDiagramUtils.Commands
{
    internal class ImportCommand : CommandBase
    {
        public ImportCommand(Args args) : base(args)
        {
        }

        public override void Perform()
        {
            //var bytesAsString = File.ReadAllText(Args.Path);
            //var bytes = Encoding.UTF8.GetBytes(bytesAsString);
            var bytes = File.ReadAllBytes(Args.Path);
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO dbo.sysdiagrams");
            sql.AppendLine("(name, principal_id, version, definition)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@Name, @PrincipalId, @Version, @Definition)");
            using (var connection = GetNewConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sql.ToString(), connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Args.Diagram;
                    command.Parameters.Add("@PrincipalId", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@Version", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@Definition", SqlDbType.VarBinary).Value = bytes;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}