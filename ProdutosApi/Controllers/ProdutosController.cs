using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Data;
using ProdutosApi.DTO;
using ProdutosApi.Models;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutosContext _context;
    private readonly IMapper _mapper;

    public ProdutosController(ProdutosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var produtos = _context.Produtos.ToList();
        return Ok(_mapper.Map<List<ProdutoDto>>(produtos));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();
        return Ok(_mapper.Map<ProdutoDto>(produto));
    }

    [HttpPost]
    public IActionResult Create(ProdutoDto dto)
    {
        var produto = _mapper.Map<Produto>(dto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, _mapper.Map<ProdutoDto>(produto));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ProdutoDto dto)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        _mapper.Map(dto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
