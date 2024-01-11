namespace Api_Arancia.Data.Dtos;

public class ReadEmpresaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<ReadProjetoDto> Projeto { get; set;}
}
