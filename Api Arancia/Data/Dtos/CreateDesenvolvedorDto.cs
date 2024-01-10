using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Data.Dtos;

public class CreateDesenvolvedorDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}
