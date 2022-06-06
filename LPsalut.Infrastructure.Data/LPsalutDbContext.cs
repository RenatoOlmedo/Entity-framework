using LPsalut.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPsalut.Infrastructure.Data
{
    internal class LPsalutDbContext : DbContext
    {
        public LPsalutDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NotaFiscal> NotaFiscals { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LPsalutDbContext).Assembly);
        }
    }
}
