using Api_Arancia.Modelos;

namespace Api_Arancia.Data.Dtos;

public class ReadDesenvolvedorDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<ReadProjetoDto> Projetos { get; set; }
}
