using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjetoController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public ProjetoController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaProjeto([FromBody] CreateProjetoDto projetoDto)
    {
        Projeto projeto = _mapper.Map<Projeto>(projetoDto);
        _context.Projeto.Add(projeto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProjetoPorId),
            new { projeto.Id}, projeto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetoDto> RecuperaProjetos()
    {
        return _mapper.Map<List<ReadProjetoDto>>(_context.Projeto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProjetoPorId(int Id)
    {
        var projeto = _context.Projeto.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto != null)
        {
            ReadProjetoDto projetoDto = _mapper.Map<ReadProjetoDto>(projeto);

            return Ok(projetoDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaProjeto(int Id, [FromBody] UpdateProjetoDto projetoDto)
    {
        Projeto projeto = _context.Projeto.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto == null)
        {
            return NotFound();
        }
        _mapper.Map(projetoDto, projeto);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaProjeto( int Id)
    {
        Projeto projeto = _context.Projeto.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto == null)
        {
            return NotFound();
        }
        _context.Remove(projeto);
        _context.SaveChanges();
        return NoContent();
    }
}
