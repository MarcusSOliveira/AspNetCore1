using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Projeto.Infra.Repository.Context;

namespace Projeto.Infra.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160407220249_AulaMigracao1")]
    partial class AulaMigracao1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto.Entities.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "IDPRODUTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50)
                        .HasAnnotation("Relational:ColumnName", "NOME");

                    b.Property<decimal>("Preco")
                        .HasAnnotation("Relational:ColumnName", "PRECO");

                    b.Property<int>("Quantidade")
                        .HasAnnotation("Relational:ColumnName", "QUANTIDADE");

                    b.HasKey("IdProduto");

                    b.HasAnnotation("Relational:TableName", "PRODUTO");
                });
        }
    }
}
