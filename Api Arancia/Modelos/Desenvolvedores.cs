using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Modelos;

public class Desenvolvedores
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }

    public virtual ICollection<Projetos> Projetos { get; set; }
}
