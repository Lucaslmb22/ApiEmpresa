using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Modelos;

public class Empresa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    [MaxLength(100)]
    public string Nome { get; set; }

    public virtual ICollection<Projeto> Projeto { get; set; }
}
