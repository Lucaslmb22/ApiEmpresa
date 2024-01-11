using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public EmpresaController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEmpresa([FromBody] CreateEmpresaDto empresaDto)
    {
        Empresa empresa = _mapper.Map<Empresa>(empresaDto);
        _context.Empresa.Add(empresa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEmpresaPorId), new { id = empresa.Id }, empresa);
    }

    [HttpGet]
    public IEnumerable<ReadEmpresaDto> RecuperaEmpresas()
    {
        return _mapper.Map<List<ReadEmpresaDto>>(_context.Empresa.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEmpresaPorId(int id)
    {
        var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);
        if (empresa == null) return NotFound();
        var empresaDto = _mapper.Map<ReadEmpresaDto>(empresa);
        return Ok(empresaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEmpresas(int id, [FromBody] UpdateEmpresaDto empresaDto)
    {
        var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);
        if (empresa == null) return NotFound();
        _mapper.Map(empresaDto, empresa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch]
    public IActionResult AtualizaEmpresaParcial(int id, JsonPatchDocument<UpdateEmpresaDto> patch)
    {
        var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);
        if (empresa == null) return NotFound();

        var empresaParaAtualizar = _mapper.Map<UpdateEmpresaDto>(empresa);

        patch.ApplyTo(empresaParaAtualizar, ModelState);

        if (!TryValidateModel(empresaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(empresaParaAtualizar, empresa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEmpresa(int id)
    {
        var empresa = _context.Empresa.FirstOrDefault(
            empresa => empresa.Id == id);
        if (empresa == null) return NotFound();
        _context.Remove(empresa);
        _context.SaveChanges();
        return NoContent();
    }


}
