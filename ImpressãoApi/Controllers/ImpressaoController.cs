using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ImpressaoApi.Data;
using ImpressaoApi.Models;
using ImpressaoApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ImpressaoController : ControllerBase
{
    private readonly ImpressaoContext _context;
    private readonly IMapper _mapper;

    public ImpressaoController(ImpressaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var logs = _context.ImpressaoLogs.ToList();
        var dto = _mapper.Map<List<ImpressaoLogDto>>(logs);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var log = _context.ImpressaoLogs.Find(id);
        if (log == null) return NotFound();
        return Ok(_mapper.Map<ImpressaoLogDto>(log));
    }

    [HttpPost]
    public IActionResult Create(ImpressaoLogDto dto)
    {
        var log = _mapper.Map<ImpressaoLog>(dto);
        _context.ImpressaoLogs.Add(log);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = log.Id }, _mapper.Map<ImpressaoLogDto>(log));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var log = _context.ImpressaoLogs.Find(id);
        if (log == null) return NotFound();

        _context.ImpressaoLogs.Remove(log);
        _context.SaveChanges();
        return NoContent();
    }
}
