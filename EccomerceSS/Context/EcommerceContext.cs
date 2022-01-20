using EccomerceSS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EccomerceSS.Context
{
    public class EcommerceContext : IdentityDbContext
    {
        

        public DbSet<NavegationBar> navegationBars { get; set; }
        public DbSet<IndexProducts> indexProducts { get; set; }
        public EcommerceContext()
        {

        }
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IndexProducts>(e =>
            {
                e.Property(e => e.price).HasColumnType("decimal(18,2)");
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-U2M982S\SQLEXPRESS;DataBase=EcommerceSS;Integrated Security=True;Connect Timeout=30;");
        }
    }
}
