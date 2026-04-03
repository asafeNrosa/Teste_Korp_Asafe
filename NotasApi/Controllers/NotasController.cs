using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NotasApi.Data;
using NotasApi.Models;
using NotasApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class NotasController : ControllerBase
{
    private readonly NotasContext _context;
    private readonly IMapper _mapper;

    public NotasController(NotasContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllNotas() =>
        Ok(_mapper.Map<List<NotaFiscalDto>>(_context.NotasFiscais.ToList()));

    [HttpGet("{id}")]
    public IActionResult GetNotaById(int id)
    {
        var nota = _context.NotasFiscais.Find(id);
        if (nota == null) return NotFound();
        return Ok(_mapper.Map<NotaFiscalDto>(nota));
    }

    [HttpPost]
    public IActionResult CreateNota(NotaFiscalDto dto)
    {
        var nota = _mapper.Map<NotaFiscal>(dto);
        _context.NotasFiscais.Add(nota);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetNotaById), new { id = nota.Id }, _mapper.Map<NotaFiscalDto>(nota));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateNota(int id, NotaFiscalDto dto)
    {
        var nota = _context.NotasFiscais.Find(id);
        if (nota == null) return NotFound();
        _mapper.Map(dto, nota);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNota(int id)
    {
        var nota = _context.NotasFiscais.Find(id);
        if (nota == null) return NotFound();
        _context.NotasFiscais.Remove(nota);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("{notaId}/produtos")]
    public IActionResult GetProdutosDaNota(int notaId) =>
        Ok(_mapper.Map<List<NotaProdutoDto>>(_context.NotaProdutos.Where(np => np.NotaId == notaId).ToList()));

    [HttpGet("{notaId}/produtos/{id}")]
    public IActionResult GetProdutoDaNota(int notaId, int id)
    {
        var produto = _context.NotaProdutos.FirstOrDefault(np => np.NotaId == notaId && np.Id == id);
        if (produto == null) return NotFound();
        return Ok(_mapper.Map<NotaProdutoDto>(produto));
    }

    [HttpPost("{notaId}/produtos")]
    public IActionResult AddProdutoNaNota(int notaId, NotaProdutoDto dto)
    {
        var nota = _context.NotasFiscais.Find(notaId);
        if (nota == null) return NotFound();

        var notaProduto = _mapper.Map<NotaProduto>(dto);
        notaProduto.NotaId = notaId;

        _context.NotaProdutos.Add(notaProduto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProdutoDaNota), new { notaId, id = notaProduto.Id }, _mapper.Map<NotaProdutoDto>(notaProduto));
    }

    [HttpPut("{notaId}/produtos/{id}")]
    public IActionResult UpdateProdutoNaNota(int notaId, int id, NotaProdutoDto dto)
    {
        var produto = _context.NotaProdutos.FirstOrDefault(np => np.NotaId == notaId && np.Id == id);
        if (produto == null) return NotFound();

        _mapper.Map(dto, produto);
        produto.NotaId = notaId;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{notaId}/produtos/{id}")]
    public IActionResult DeleteProdutoDaNota(int notaId, int id)
    {
        var produto = _context.NotaProdutos.FirstOrDefault(np => np.NotaId == notaId && np.Id == id);
        if (produto == null) return NotFound();

        _context.NotaProdutos.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
