using System.ComponentModel;

namespace Integracao.Domain.Eventos.Enums
{
   public enum AtendimentoEnum
    {
        [Description("Clínico")]
        Clinico = 1,
        [Description("Cirurgico")]
        Cirurgico = 2,
        [Description("Pré natal")]
        PreNatal = 3,
    }
}
