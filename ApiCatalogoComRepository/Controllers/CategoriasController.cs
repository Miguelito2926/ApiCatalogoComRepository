using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.DTOs;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;
using ApiCatalogoComRepository.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiCatalogoComRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    // Declaração do contexto do banco de dados
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    // Construtor que recebe o contexto do banco de dados como parâmetro
    public CategoriasController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    // Endpoint para obter todas as categorias com seus produtos
    [HttpGet("produtos")]
    public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasProdutos([FromQuery] CategoriasParameters categoriasParameters)
    {
        try
        {
            var categorias = _uof.CategoriaRepository.GetCategoriasProdutos(categoriasParameters);
            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return Ok(categoriasDto);
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
    public ActionResult<IEnumerable<CategoriaDTO>> Get([FromQuery] CategoriasParameters categoriasParameters)
    {
        // Utilizando AsNoTracking para consultas que não precisam rastrear alterações
        var categorias = _uof.CategoriaRepository.GetCategorias(categoriasParameters);
        var metadata = new
        {
            categorias.TotalCount,
            categorias.PageSize,
            categorias.CurrentPage,
            categorias.TotalPages,
            categorias.HasNext,
            categorias.HasPrevious
        };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
        return Ok(categoriasDto);
    }


    // Endpoint para obter uma categoria por ID usando restrição de rota definindo que espera um ID do tipo inteiro maior que 0
    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    public ActionResult<CategoriaDTO> Get(int id)
    {
        try
        {
        var categoria = _uof.CategoriaRepository.GetById(p => p.CategoriaId == id);
            if (categoria == null)
            {
                // Retornando NotFound com uma mensagem personalizada
                return NotFound("Recurso não encontrado.");
            }
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            // Retornando Ok com a categoria encontrada
            return Ok(categoriaDto);
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
    public ActionResult Post(CategoriaDTO categoriaDto)
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            if (categoria is null)
            {
                // Retornando BadRequest com uma mensagem personalizada
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            _uof.CategoriaRepository.Add(categoria);
            _uof.Commit();
            // Utilizando CreatedAtRouteResult para retornar um código 201 com a rota de obtenção da categoria criada
            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaId }, categoriaDTO);
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
    public ActionResult Put(int id, CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
        {
            // Retornando BadRequest com uma mensagem personalizada
            return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
        }
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        _uof.CategoriaRepository.Update(categoria);
        _uof.Commit();
        var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

        // Retornando Ok com a categoria modificada
        return Ok(categoriaDTO);
    }

    // Endpoint para excluir uma categoria
    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
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
            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            // Retornando Ok com a categoria removida
            return Ok(categoriaDTO);
        }
        catch (Exception)
        {
            // Retornando BadRequest com uma mensagem personalizada
            return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
        }
    }
}


