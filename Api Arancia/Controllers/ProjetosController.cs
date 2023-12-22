using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjetosController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public ProjetosController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaProjetos([FromBody] CreateProjetosDto projetosDto)
    {
        Projetos projeto = _mapper.Map<Projetos>(projetosDto);
        _context.Projetos.Add(projeto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProjetosPorId),
            new { projeto.Id}, projeto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetosDto> RecuperaProjetos()
    {
        return _mapper.Map<List<ReadProjetosDto>>(_context.Projetos);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProjetosPorId(int Id)
    {
        var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto != null)
        {
            ReadProjetosDto projetosDto = _mapper.Map<ReadProjetosDto>(projeto);

            return Ok(projetosDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaProjetos(int Id, [FromBody] UpdateProjetosDto projetosDto)
    {
        Projetos projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto == null)
        {
            return NotFound();
        }
        _mapper.Map(projetosDto, projeto);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco( int Id)
    {
        Projetos projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto == null)
        {
            return NotFound();
        }
        _context.Remove(projeto);
        _context.SaveChanges();
        return NoContent();
    }
}
