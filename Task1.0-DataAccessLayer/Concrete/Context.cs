using Microsoft.EntityFrameworkCore;
using Task1._0_EntityLayer.Concrete;

namespace Task1._0_DataAccessLayer.Concrete;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Task;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;Encrypt=false;");
    }
    
    public DbSet<Order> Orders { get; set; }
}
