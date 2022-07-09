
using Microsoft.Data.SqlClient;

namespace Pizza.Sourse
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TableUsers> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                ["Server"] = @"(localdb)\mssqllocaldb", // адрес БД к которой подключаемся
                ["Database"] = "EfCoreBasicDb", // имя БД
                ["Trusted_Connection"] = true // используем аутентификацию Windows
            };
            optionsBuilder
                .UseSqlServer(connectionStringBuilder.ConnectionString); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // автоматически применяем все IEntityTypeConfiguration из текущей сборки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
