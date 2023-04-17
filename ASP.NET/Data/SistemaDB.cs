using ASP.NET.NovaPasta;
using Microsoft.EntityFrameworkCore; //biblioteca

namespace ASP.NET.Data
{
    public class SistemaDB : DbContext
    {
        public SistemaDB(DbContextOptions<SistemaDB> options)
            : base(options)
        {
        }
        //trabalhando com ORM: facilita com o banco de dados
        //fazer toda a estrutura de entidade pra dentro do código
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamModel>()
                .HasData(
                    new TeamModel { Id = 1, Name = "contador", sector = "financeiro" });
               
            modelBuilder.Entity<EmployeeModel>()
               .HasOne(o => o.Team)
                .WithMany(c => c.Employee)
                .HasForeignKey(o => o.TeamReference)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
