using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    //Por onde esta o banco de dados para o DbContext saber , meu optionsBuilder.UseMySql(""); vai receber 2 parametros , a connectionString e o ServerVersion
    //Version(8, 0, 33)); os 3 numeros que aparecem na sessao Version do MySql 
    //(Sintaxe do MySql o Sql Server é diferente) ConnectionString: "server=localhost;Database=cashflowdb;Uid=root;Pwd=@060523Li;"

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;port=3307;Database=cashflowdb;Uid=root;Pwd=@060523Li;";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 44));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
