using LojaVirtual.Data;
using LojaVirtual.Dto;
using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Services
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int id)
        {
            ResponseModel<ProdutoModel> response = new ResponseModel<ProdutoModel>();

            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if(produto == null)
                {
                    response.Mensagem = "Produto não encontrado";
                    return response;
                }
                else
                {
                    response.Dados = produto;
                    response.Mensagem = "Produto encontrado!";
                    return response;
                }           
            } catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<ProdutoModel>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            ResponseModel<ProdutoModel> response = new ResponseModel<ProdutoModel>();

            try
            {
                var produtoBanco = await _context.Produtos.FindAsync(produtoEdicaoDto.Id);

                if( produtoBanco == null)
                {
                    response.Mensagem = "Produto não encontrado";
                    return response;
                }
                produtoBanco.Nome = produtoEdicaoDto.Nome;
                produtoBanco.Descricao = produtoEdicaoDto.Descricao;
                produtoBanco.Preco = produtoEdicaoDto.Preco;
                produtoBanco.DataCadastro = produtoEdicaoDto.DataCadastro;
                produtoBanco.CategoriaId = produtoEdicaoDto.CategoriaId;

                _context.Update(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto alterado com sucesso!";
                response.Dados = produtoBanco;
                return response;

            } catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
                
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> response = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                response.Dados = produtos;
                response.Mensagem = "Produtos localizados!";
                return response;

            } catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> RegistrarProduto(ProdutoDto produtoDto)
        {
            ResponseModel<ProdutoModel> response = new ResponseModel<ProdutoModel>();
           
            try
            {
                if (ProdutoJaExiste(produtoDto))
                {
                    response.Mensagem = "Produto já registrado!";
                    response.Status = false;
                    return response;
                }

                //Criação do produto
                var produto = new ProdutoModel 
                { 
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    Preco = produtoDto.Preco,
                    DataCadastro = produtoDto.DataCadastro,
                    CategoriaId = produtoDto.CategoriaId           
                };

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto cadastrado com sucesso!";
                response.Status = true;
                response.Dados = produto;

                var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == produtoDto.CategoriaId);
                if (!categoriaExiste)
                {
                    response.Mensagem = "Categoria informada não existe.";
                    response.Status = false;
                    return response;
                }


            } catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<ProdutoModel>> RemoverProduto(int id)
        {
            ResponseModel<ProdutoModel> response = new ResponseModel<ProdutoModel>();

            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if(produto == null)
                {
                    response.Mensagem = "Produto não localizado!";
                    return response;
                }
                else
                {
                    response.Dados = produto;
                    response.Mensagem = "Produto removido com sucesso";

                    _context.Remove(produto);
                    await _context.SaveChangesAsync();
                    return response;
                }
            } catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public bool ProdutoJaExiste(ProdutoDto produtoDto)
        {
            return _context.Produtos.Any(item => item.Nome == produtoDto.Nome);
        }

    }

     
}
