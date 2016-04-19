using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity; //entityframework
using Projeto.Entities; //entidades
using Projeto.Infra.Repository.Context; //classe de conexão

namespace Projeto.Infra.Repository.Persistence
{
    public class ProdutoRepository
    {
        public void Insert(Produto p)
        {
            using (var d = new DataContext())
            {
                d.Entry(p).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Update(Produto p)
        {
            using (var d = new DataContext())
            {
                d.Entry(p).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public void Delete(Produto p)
        {
            using (var d = new DataContext())
            {
                d.Entry(p).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<Produto> FindAll()
        {
            using (var d = new DataContext())
            {
                return d.Produtos.ToList();
            }
        }

        public Produto FindById(int idProduto)
        {
            using (var d = new DataContext())
            {
                return d.Produtos.FirstOrDefault(p => p.IdProduto == idProduto);
            }
        }
    }
}
