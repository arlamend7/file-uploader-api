using Integracao.Conversores.Base.Interfaces;
using Integracao.Conversores.Sul_America.Beneficiarios;
using Integracao.Conversores.Sul_America.Eventos;
using Integracao.Domain.Importacoes.Enumeradores;

namespace Integracao.Conversores.Sul_America
{
    public class SulAmericaConverter : IOperadoraConverter
    {
        public IOperadoraFileConverter IdentificaArquivo(ClasseArquivoEnum arquivo)
        {
            return arquivo switch
            {
                ClasseArquivoEnum.Beneficiario => new BeneficiarioConverter(),
                ClasseArquivoEnum.Eventos => new EventoConverter(),
                _ => throw new NotSupportedException()
            };
        }
       
    }
}
