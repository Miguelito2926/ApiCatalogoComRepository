using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    public ProdutosController(IUnitOfWork contexto) // injeção de dependencia
    {
        _uof = contexto;
        // Inicializa o controlador com o contexto do banco de dados.
    }

    [HttpGet("menorpreco")]
    public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
    {
        return _uof.ProdutoRepository.GetProdutosPorPreco().ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        return _uof.ProdutoRepository.Get().ToList();        
    }

  
    // Endpoint para obter uma produto por ID usando restrição de rota definindo que espera um ID do tipo inteiro maior que 0
    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        try
        {
            // Método que responde a solicitações HTTP GET para obter um produto específico por ID.
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Recurso não encontrado.");
            }
            return produto;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        try
        {
            // Método que responde a solicitações HTTP POST para criar um novo produto.
            if (produto is null)
            {
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        try
        {
            // Método que responde a solicitações HTTP PUT para atualizar um produto existente.
            if (id != produto.ProdutoId)
            {
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            // Método que responde a solicitações HTTP DELETE para excluir um produto por ID.
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Recurso não encontrado.");
            }
            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return Ok(produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
               "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }

    }
}

