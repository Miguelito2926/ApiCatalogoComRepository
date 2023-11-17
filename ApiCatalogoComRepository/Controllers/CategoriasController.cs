using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    // Declaração do contexto do banco de dados
    private readonly IUnitOfWork _uof;

    // Construtor que recebe o contexto do banco de dados como parâmetro
    public CategoriasController(IUnitOfWork context)
    {
        _uof = context;
    }

    // Endpoint para obter todas as categorias com seus produtos
    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        try
        {
            return _uof.CategoriaRepository.GetCategoriasProdutos().ToList(); 
        }
        catch (Exception)
        {
            // Retornando um erro interno do servidor em caso de exceção
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }
    }

    // Endpoint para obter todas as categorias
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetAll()
    {
        // Utilizando AsNoTracking para consultas que não precisam rastrear alterações
        return _uof.CategoriaRepository.Get().ToList();
    }

    // Endpoint para obter uma categoria por ID usando restrição de rota definindo que espera um ID do tipo inteiro maior que 0
    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        try
        {
            var categoria = _uof.CategoriaRepository.GetById(p => p.CategoriaId == id);
            if (categoria == null)
            {
                // Retornando NotFound com uma mensagem personalizada
                return NotFound("Recurso não encontrado.");
            }

            // Retornando Ok com a categoria encontrada
            return Ok(categoria);
        }
        catch (Exception)
        {
            // Retornando um erro interno do servidor em caso de exceção
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }
    }

    // Endpoint para adicionar uma nova categoria
    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
            {
                // Retornando BadRequest com uma mensagem personalizada
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            _uof.CategoriaRepository.Add(categoria);
            _uof.Commit();
            // Utilizando CreatedAtRouteResult para retornar um código 201 com a rota de obtenção da categoria criada
            return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaId }, categoria);
        }
        catch (Exception)
        {
            // Retornando um erro interno do servidor em caso de exceção
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }
    }

    // Endpoint para atualizar uma categoria existente
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            // Retornando BadRequest com uma mensagem personalizada
            return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
        }
        _uof.CategoriaRepository.Update(categoria);
        _uof.Commit();

        // Retornando Ok com a categoria modificada
        return Ok(categoria);
    }

    // Endpoint para excluir uma categoria
    [HttpDelete("{id:int}")]
    public ActionResult<Categoria> Delete(int id)
    {
        try
        {
            var categoria = _uof.CategoriaRepository.GetById(p => p.CategoriaId == id);

            if (categoria == null)
            {
                // Retornando NotFound com uma mensagem personalizada
                return NotFound("Recurso não encontrado.");
            }
            _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();

            // Retornando Ok com a categoria removida
            return Ok(categoria);
        }
        catch (Exception)
        {
            // Retornando BadRequest com uma mensagem personalizada
            return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
        }
    }
}


