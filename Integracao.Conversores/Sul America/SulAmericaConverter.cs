using Integracao.Conversores.Base.Interfaces;
using Integracao.Conversores.Sul_America.Beneficiarios;
using Integracao.Conversores.Sul_America.Eventos;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Sul_America
{
    public class SulAmericaConverter : IOperadoraConverter
    {

        

        public void IdentificaArquivo(string arquivo)
        {

        }

        Func<Stream, IEnumerable<EntityBase>> IOperadoraConverter.IdentificaArquivo(string arquivo)
        {
            return arquivo switch
            {
                "Beneficiarios" => BeneficiarioConverter.Convert,
                "Eventos" => EventoConverter.Convert
            };   
        }
    }
}
