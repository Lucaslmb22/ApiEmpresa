using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]
public class DesenvolvedoresController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public DesenvolvedoresController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AdicionaDesenvolvedores([FromBody] CreateDesenvolvedoresDto desenvolvedoresDto)
    {
        Desenvolvedores desenvolvedores = _mapper.Map<Desenvolvedores>(desenvolvedoresDto);
        _context.Desenvolvedores.Add(desenvolvedores);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDesenvolvedoresPorId), new { desenvolvedores.Id }, desenvolvedoresDto);
    }

    [HttpGet]
    public IEnumerable<ReadDesenvolvedoresDto> RecuperaDesenvolvedores()
    {
        return _mapper.Map<List<ReadDesenvolvedoresDto>>(_context.Desenvolvedores.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaDesenvolvedoresPorId(int id)
    {
        Desenvolvedores desenvolvedores = _context.Desenvolvedores.FirstOrDefault(desenvolvedores => desenvolvedores.Id == id);
        if (desenvolvedores != null)
        {
            ReadDesenvolvedoresDto desenvolvedoresDto = _mapper.Map<ReadDesenvolvedoresDto>(desenvolvedores);
            return Ok(desenvolvedoresDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDesenvolvedores(int id, [FromBody] UpdateDesenvolvedoresDto desenvolvedoresDto)
    {
        Desenvolvedores desenvolvedores = _context.Desenvolvedores.FirstOrDefault(desenvolvedores => desenvolvedores.Id == id);
        if (desenvolvedores == null)
        {
            return NotFound();
        }
        _mapper.Map(desenvolvedoresDto, desenvolvedores);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        Desenvolvedores desenvolvedores = _context.Desenvolvedores.FirstOrDefault(desenvolvedores => desenvolvedores.Id == id);
        if (desenvolvedores == null)
        {
            return NotFound();
        }
        _context.Remove(desenvolvedores);
        _context.SaveChanges();
        return NoContent();
    }

}
