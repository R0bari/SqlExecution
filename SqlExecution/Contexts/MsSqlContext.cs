using SqlExecution.Entities;
using System.Configuration;
using System.Data.Entity;

namespace SqlExecution.Contexts
{
    internal class MsSqlContext : DbContext, IExecute
    {
        private static readonly string _connectionString = ConfigurationManager.AppSettings["MsSqlConnectionString"] ?? "";

        public MsSqlContext() : base(_connectionString)
        {
        }

        public DbSet<Operation> Operations { get; set; }

        public int Execute(string sqlCommand, params object[] parameters) =>
            Database.ExecuteSqlCommand(sqlCommand, parameters);
    }
}
