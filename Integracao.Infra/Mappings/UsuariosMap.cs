using FluentNHibernate.Mapping;
using Integracao.Domain.Usuarios.Entidades;

namespace Integracao.Infra.Mappings
{
    public class UsuariosMap : ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Table("Usuario");
            Id(x => x.Codigo).Column("UsuarioId");
            Map(x => x.Nome);
            Map(x => x.Senha);
        }
    }
}
