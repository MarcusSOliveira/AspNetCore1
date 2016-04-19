using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Projeto.Entities; //entidades..
using Projeto.Infra.Repository.Persistence; //persistencia..
using Projeto.WebApi.Models; //classes de modelo..

namespace Projeto.WebApi.Controllers
{
    //[controller] -> faz referencia ao nome do controller..
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        [HttpPost] //requisições POST..
        [Route("cadastrar")] //URL: /api/produto/cadastrar
        public IActionResult Post([FromBody]ProdutoModelCadastro model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Produto p = new Produto()
                    {
                        Nome = model.Nome,
                        Preco = model.Preco,
                        Quantidade = model.Quantidade
                    };

                    var rep = new ProdutoRepository(); //persistencia..
                    rep.Insert(p); //gravando o produto..

                    //retorna status 200 com mensagem de sucesso..
                    return new HttpOkObjectResult("Produto cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    //retorna status 400 com mensagem de erro..
                    return new BadRequestObjectResult(e.Message);
                }
            }
            else
            {
                //montar uma lista com as mensagens de erro de validação..
                var listagemErros = new List<string>();
                foreach(var s in ModelState)
                {
                    foreach(var e in s.Value.Errors)
                    {
                        listagemErros.Add(e.ErrorMessage);
                    }
                }

                //TO DO... alterar para forbidden
                return new BadRequestObjectResult(listagemErros);
            }
        }


        [HttpPut] //requisições PUT..
        [Route("atualizar")] //URL: /api/produto/atualizar
        public IActionResult Put([FromBody]ProdutoModelEdicao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto p = new Produto()
                    {
                        IdProduto = model.IdProduto,
                        Nome = model.Nome,
                        Preco = model.Preco,
                        Quantidade = model.Quantidade
                    };

                    var rep = new ProdutoRepository(); //persistencia..
                    rep.Update(p); //atualizando o produto..

                    //retorna status 200 com mensagem de sucesso..
                    return new HttpOkObjectResult("Produto atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    //retorna status 400 com mensagem de erro..
                    return new BadRequestObjectResult(e.Message);
                }
            }
            else
            {
                //montar uma lista com as mensagens de erro de validação..
                var listagemErros = new List<string>();
                foreach (var s in ModelState)
                {
                    foreach (var e in s.Value.Errors)
                    {
                        listagemErros.Add(e.ErrorMessage);
                    }
                }

                //TO DO... alterar para forbidden
                return new BadRequestObjectResult(listagemErros);
            }
        }


        [HttpDelete]
        [Route("excluir")] //URL: /api/produto/excluir?id=1
        public IActionResult Delete(int id)
        {
            try
            {
                var rep = new ProdutoRepository(); //persistencia..

                //buscar o produto pelo id..
                Produto p = rep.FindById(id);

                //verificar se o produto foi encontrado..
                if(p != null)
                {
                    rep.Delete(p); //excluindo..

                    //retornar status de sucesso 200 com mensagem..
                    return new HttpOkObjectResult("Produto excluido com sucesso.");
                }
                else
                {
                    throw new Exception("Produto não encontrado.");
                }
            }
            catch(Exception e)
            {
                //retornar status de erro 400 com mensagem..
                return new BadRequestObjectResult(e.Message);
            }
        }


        [HttpGet]
        [Route("consultar")] //URL: /api/produto/consultar
        public IActionResult GetValues()
        {
            try
            {
                var lista = new List<ProdutoModelConsulta>();

                var rep = new ProdutoRepository(); //persistencia
                foreach(var p in rep.FindAll())
                {
                    var model = new ProdutoModelConsulta()
                    {
                        IdProduto = p.IdProduto,
                        Nome = p.Nome,
                        Preco = p.Preco,
                        Quantidade = p.Quantidade
                    };

                    lista.Add(model); //adicionando..
                }

                return new HttpOkObjectResult(lista);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }


        [HttpGet]
        [Route("obter")] //URL: /api/produto/obter?id=1
        public IActionResult GetValue(int id)
        {
            try
            {
                var rep = new ProdutoRepository(); //persistencia
                var p = rep.FindById(id);

                if(p != null) //se o produto foi encontrado..
                {
                    var model = new ProdutoModelConsulta()
                    {
                        IdProduto = p.IdProduto,
                        Nome = p.Nome,
                        Preco = p.Preco,
                        Quantidade = p.Quantidade
                    };

                    return new HttpOkObjectResult(model);
                }
                else
                {
                    throw new Exception("Produto não encontrado.");
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

    }
}
