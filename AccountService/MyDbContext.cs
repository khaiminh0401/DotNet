using Microsoft.EntityFrameworkCore;
using AccountService.Entities;

namespace AccountService.DBContext;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public string Server { get; set; } = "MSI\\DKM";
    public string Database { get; set; } = "TrainingNet";
    public string Username { get; set; } = "sa";
    public string Password { get; set; } = "04012003";

    // public DbConnection GetDbConnection()
    // {
    //     return new SqlConnection($"Data Source={this.Server};Initial Catalog={this.Database};User ID={this.Username};Password={this.Password}");
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Data Source={Server};Initial Catalog={Database};User ID={Username};Password={Password}");
    }

    public DbSet<Account> Account { get; set; }
}