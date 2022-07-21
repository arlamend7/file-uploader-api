using Integracao.Conversores.Base.Delegates;
using Integracao.Conversores.Base.Interfaces;
using Integracao.Conversores.Sul_America.Beneficiarios;
using Integracao.Domain.Importacoes.Enumeradores;

namespace Integracao.Conversores.Sul_America
{
    public class SulAmericaConverter : IOperadoraConverter
    {
        FileConvert IOperadoraConverter.IdentificaArquivo(ClasseArquivoEnum arquivo)
        {
            return arquivo switch
            {
                ClasseArquivoEnum.Beneficiario => BeneficiarioConverter.Convert,
                _ => throw new NotSupportedException()
            };
        }
    }
}
