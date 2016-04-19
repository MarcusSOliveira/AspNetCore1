using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Builders; //mapeamento..
using Microsoft.Data.Entity; //mapeamento..
using Projeto.Entities; //entidades..

namespace Projeto.Infra.Repository.Configurations
{
    public class ProdutoConfiguration
    {
        //construtor..
        public ProdutoConfiguration(EntityTypeBuilder<Produto> map)
        {
            //nome da tabela..
            map.ToTable("PRODUTO");

            //chave primária..
            map.HasKey(p => p.IdProduto);

            //demais propriedades..
            map.Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO");

            map.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            map.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .IsRequired();

            map.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();
        }
    }
}
