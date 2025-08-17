using Api.Src.Infrastructure.Sqlite.Models;
using Api.Src.Util.Di;
using Microsoft.EntityFrameworkCore;


namespace Api.Src.Infrastructure.Sqlite
{
    [iBaseServiceAttribute(eServiceScope.Scoped)]
    public class SqlLiteInfrastructure : DbContext
    {
        public DbSet<PaymentModel> PaymentModel { get; set; }

        public SqlLiteInfrastructure() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=pol.db");
            }
        }
    }
}