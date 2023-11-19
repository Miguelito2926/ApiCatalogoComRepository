
using ApiCatalogoComRepository.DTOs;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;
using ApiCatalogoComRepository.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiCatalogoComRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;// injeção de dependencia

    private readonly IMapper _mapper;// injeção de dependencia

    public ProdutosController(IUnitOfWork contexto, IMapper mapper) 
    {
        _uof = contexto; // Inicializa o controlador com o contexto do banco de dados.
        _mapper = mapper;
    }

    [HttpGet("menorpreco")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosPrecos([FromQuery]ProdutosParameters produtosParameters)
    {
        var produtos = _uof.ProdutoRepository.GetProdutosPorPreco(produtosParameters);
        var metadata = new
        {
            produtos.TotalCount,
            produtos.PageSize,
            produtos.CurrentPage,
            produtos.TotalPages,
            produtos.HasNext,
            produtos.HasPrevious
        };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
        return Ok(produtosDto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get([FromQuery] ProdutosParameters produtosParameters)
    {
        var produtos = _uof.ProdutoRepository.GetProdutos(produtosParameters);
        var metadata = new 
        { 
            produtos.TotalCount,
            produtos.PageSize,
            produtos.CurrentPage,
            produtos.TotalPages,
            produtos.HasNext,
            produtos.HasPrevious
        };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        var ProdutosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
        return ProdutosDto;
    }

  
    // Endpoint para obter uma produto por ID usando restrição de rota definindo que espera um ID do tipo inteiro maior que 0
    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        try
        {
            // Método que responde a solicitações HTTP GET para obter um produto específico por ID.
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Recurso não encontrado.");
            }
            var produtoDto = _mapper.Map<ProdutoDTO>(produto);
            return produtoDto;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }
    }

    [HttpPost]
    public ActionResult Post(ProdutoDTO produtoDto)
    {
        try
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            // Método que responde a solicitações HTTP POST para criar um novo produto.
            if (produto is null)
            {
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();
            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produtoDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, ProdutoDTO produtoDto)
    {
        try
        {
            // Método que responde a solicitações HTTP PUT para atualizar um produto existente.
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest("Bad Request. Campos obrigatórios de entrada não enviados ou erros de validação dos campos de entrada.");
            }
            var produto = _mapper.Map<Produto>(produtoDto);
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
    public ActionResult<ProdutoDTO> Delete(int id)
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
            var produtoDto = _mapper.Map<ProdutoDTO>(produto);
            return Ok(produtoDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
               "Internal Server Error. Solicitação não enviada. Precisa ser executada novamente.");
        }

    }
}

