using DataBase.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proposta> Proposta { get; set; }
        public DbSet<Contratacao> Contratacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contratacao>()
                .HasOne(c => c.Proposta)
                .WithMany(p => p.Contratacoes)
                .HasForeignKey(c => c.IdProposta);
        }
    }
}