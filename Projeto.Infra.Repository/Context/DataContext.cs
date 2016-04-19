using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity; //entityframework 7
using Projeto.Entities; //entidades
using Projeto.Infra.Repository.Configurations; //mapeamento..

namespace Projeto.Infra.Repository.Context
{
    public class DataContext : DbContext
    {
        //sobrescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //classes de mapeamento..
            new ProdutoConfiguration(modelBuilder.Entity<Produto>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Aula;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        //declarar um DbSet para cada entidade..
        public DbSet<Produto> Produtos { get; set; }
    }
}
