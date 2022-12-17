


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Plantilla_S_EF.Context
{
    public class PrincipalContext:DbContext
    {

        private IConfiguration _configuration;
        public PrincipalContext() { 
        
        
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
    }
}
