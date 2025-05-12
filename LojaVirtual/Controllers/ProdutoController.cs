using LojaVirtual.Dto;
using LojaVirtual.Models;
using LojaVirtual.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpPost("upload-produtos")]
        public async Task<IActionResult> Upload([FromForm] ProdutoUploadDto dto)
        {
            if (dto.Imagens == null || dto.Imagens.Count == 0)
                return BadRequest("Nenhum arquivo foi enviado");

            var imagemUrls = new List<string>();

            foreach (var imagem in dto.Imagens)
            {
                if (imagem.Length > 0)
                {
                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                    var caminho = Path.Combine("wwwroot/imagens", nomeArquivo);

                    // Cria o diretório se não existir
                    Directory.CreateDirectory(Path.GetDirectoryName(caminho)!);

                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    imagemUrls.Add($"/imagens/{nomeArquivo}");
                }
            }

            // Exemplo: salva apenas a primeira imagem no campo ImagemUrl
            var produto = new ProdutoModel
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                CategoriaId = dto.CategoriaId,
                ImagemUrl = imagemUrls.FirstOrDefault() // se tiver imagem
            };

            // Aqui você pode salvar no banco, etc.
            return Ok(produto);
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarProduto(ProdutoDto produtoDto)
        {
            var produto = await _produtoInterface.RegistrarProduto(produtoDto);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produto = await _produtoInterface.ListarProdutos();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(id);
            return Ok(produto);
        }

        [HttpPut]
        public async Task<IActionResult> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            var produto = await _produtoInterface.EditarProduto(produtoEdicaoDto);
            return Ok(produto);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            var produto = await _produtoInterface.RemoverProduto(id);
            return Ok(produto);
        }

    }
}
