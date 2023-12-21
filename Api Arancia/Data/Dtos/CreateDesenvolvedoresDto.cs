using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Data.Dtos;

public class CreateDesenvolvedoresDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}
