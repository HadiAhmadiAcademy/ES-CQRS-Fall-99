using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Projections.Sql.Handlers.Model
{
    public class LoanApplicationContext : DbContext
    {
        public DbSet<LoanApplication> LoanApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "data source=.;integrated security=true;initial catalog=LoanApplicationProjection");
            base.OnConfiguring(optionsBuilder);
        }
    }
}