using Api_Arancia.Modelos;

namespace Api_Arancia.Data.Dtos;

public class ReadDesenvolvedoresDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<ReadProjetosDto> Projetos { get; set; }
}
