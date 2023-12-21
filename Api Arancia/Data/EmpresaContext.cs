using Api_Arancia.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Api_Arancia.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Projetos>()
            .HasKey(projeto => new { projeto.EmpresaId, projeto.DesenvolvedoresId });

        builder.Entity<Projetos>()
            .HasOne(projeto => projeto.Empresa)
            .WithMany(empresa => empresa.Projetos)
            .HasForeignKey(projeto => projeto.EmpresaId);

        builder.Entity<Projetos>()
            .HasOne(projeto => projeto.Desenvolvedores)
            .WithMany(desenvolvedores => desenvolvedores.Projetos)
            .HasForeignKey(projeto => projeto.DesenvolvedoresId);
    }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Projetos> Projetos { get; set; }
    public DbSet<Desenvolvedores> Desenvolvedores { get; set; }
}
