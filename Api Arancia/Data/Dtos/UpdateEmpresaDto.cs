using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Data.Dtos;

public class UpdateEmpresaDto
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }
}
