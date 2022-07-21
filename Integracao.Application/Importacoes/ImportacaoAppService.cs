using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores;
using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Domain.Planos.Entidades;

namespace Integracao.Application.Importacoes
{
    public class ImportacaoAppService : IImportacaoAppService
    {

        private readonly ConverterFactory _converterFactory;

        public ImportacaoAppService(ConverterFactory converterFactory)
        {
            _converterFactory = converterFactory;
        }

        public FileConverterResult ImportarArquivos(ClasseArquivoEnum nomeArquivo, Stream arquivo, OperadorasEnum operadora)
        {
            FileConverterResult result = _converterFactory
                                .Config(operadora)
                                .IdentificaArquivo(nomeArquivo)
                                .Invoke(arquivo, out IEnumerable<Type> types);

            var planos = result.Get<Plano>();
            var beneficiarios = result.Get<Beneficiario>();
            var beneficiarioPlanos = result.Get<BeneficiarioPlano>();

            return result;
        }
    }
}
