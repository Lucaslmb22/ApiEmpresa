using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]
public class DesenvolvedorController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public DesenvolvedorController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AdicionaDesenvolvedores([FromBody] CreateDesenvolvedorDto desenvolvedorDto)
    {
        Desenvolvedor desenvolvedor = _mapper.Map<Desenvolvedor>(desenvolvedorDto);
        _context.Desenvolvedor.Add(desenvolvedor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDesenvolvedorPorId), new { desenvolvedor.Id }, desenvolvedorDto);
    }

    [HttpGet]
    public IEnumerable<ReadDesenvolvedorDto> RecuperaDesenvolvedor()
    {
        return _mapper.Map<List<ReadDesenvolvedorDto>>(_context.Desenvolvedor.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaDesenvolvedorPorId(int id)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor != null)
        {
            ReadDesenvolvedorDto desenvolvedoresDto = _mapper.Map<ReadDesenvolvedorDto>(desenvolvedor);
            return Ok(desenvolvedoresDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDesenvolvedor(int id, [FromBody] UpdateDesenvolvedorDto desenvolvedorDto)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor == null)
        {
            return NotFound();
        }
        _mapper.Map(desenvolvedorDto, desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch]
    public IActionResult AtualizaDesenvolvedorParcial(int id, JsonPatchDocument<UpdateDesenvolvedorDto> patch)
    {
        var desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor == null) return NotFound();

        var desenvolvedorParaAtualizar = _mapper.Map<UpdateDesenvolvedorDto>(desenvolvedor);

        patch.ApplyTo(desenvolvedorParaAtualizar, ModelState);

        if (!TryValidateModel(desenvolvedorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(desenvolvedorParaAtualizar, desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaDesenvolvedor(int id)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor == null)
        {
            return NotFound();
        }
        _context.Remove(desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }

}
