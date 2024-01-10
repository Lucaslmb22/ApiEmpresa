using Api_Arancia.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Api_Arancia.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> opts) : base(opts)
    {

    }
    



    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Projeto> Projeto { get; set; }
    public DbSet<Desenvolvedor> Desenvolvedor { get; set; }
}
