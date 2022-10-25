using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Projeto.Domain;
using Projeto.Domain.Extensions;

namespace Projeto.Infra;

public sealed partial class ProjetoContext : DbContext
{
    private IConfiguration Configuration { get; }

    public ProjetoContext(DbContextOptions<ProjetoContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Prevenir ações em cascata para Migrações
        mb.Model.GetEntityTypes().Where(e => !e.IsOwned())
            .SelectMany(e => e.GetForeignKeys())
            .ForEach(PreventCascade);
        MapProducts(mb);
    }


    private void PreventCascade(IMutableForeignKey fk)
    {
        fk.DeleteBehavior = DeleteBehavior.Restrict;
    }

    private static ValueConverter<TId, Guid> GetIdConverterFor<TId>() where TId : IdRecord?
        => new(v => v != null ? v.Guid : Guid.Empty, v => v.ToType<TId>());

    private static ValueConverter<TId?, Guid?> GetNullableIdConverterFor<TId>() where TId : IdRecord
        => new(v => v == null ? null : v.Guid, v => v.HasValue ? v.Value.ToType<TId>() : null);
}
