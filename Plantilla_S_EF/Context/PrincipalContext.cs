using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plantilla_S_EF.Models;
using System;

namespace Plantilla_S_EF.Context
{
    public partial class PrincipalContext : DbContext
    {
        private IConfiguration _configuration;
        public PrincipalContext()
        {
        }

        public PrincipalContext(IConfiguration configuration, DbContextOptions<PrincipalContext> options) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString("PrincipalConnection").ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }
        public virtual DbSet<Country> countries { get; set; }
        public virtual DbSet<City> cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>(e =>
            {
                e.HasOne(c => c.country)
                .WithMany(c => c.cities)
                .HasForeignKey(f => f.id_country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
