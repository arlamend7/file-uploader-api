using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Interfaces;
using Integracao.Conversores.Sul_America.Beneficiarios;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Sul_America
{
    public class SulAmericaConverter : IOperadoraConverter
    {

        

        public void IdentificaArquivo(string arquivo)
        {

        }

        Func<Stream, FileConverterResult> IOperadoraConverter.IdentificaArquivo(string arquivo)
        {
            return arquivo switch
            {
                _ => BeneficiarioConverter.Convert
            };
        }
    }
}
