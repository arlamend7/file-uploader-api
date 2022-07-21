using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores;
using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Domain.Planos.Entidades;
using Integracao.Infra.Repositories;

namespace Integracao.Application.Importacoes
{
    public class ImportacaoAppService : IImportacaoAppService
    {
        private readonly PlanoRepository _planoRepository;
        private readonly IManipulationRepository _manipulationRepository;
        private readonly ConverterFactory _converterFactory;

        public ImportacaoAppService(PlanoRepository planoRepository, IManipulationRepository manipulationRepository, ConverterFactory converterFactory)
        {
            _converterFactory = converterFactory;
            _manipulationRepository = manipulationRepository;
            _planoRepository = planoRepository;
        }

        public FileConverterResult ImportarArquivos(ClasseArquivoEnum nomeArquivo, Stream arquivo, OperadorasEnum operadora)
        {
            Importacao entity = new Importacao("null.csv", arquivo.Length, nomeArquivo, operadora);

            _manipulationRepository.Insert(entity);

            
            FileConverterResult result = _converterFactory
                                .Config(operadora)
                                .IdentificaArquivo(nomeArquivo)
                                .Invoke(arquivo, out IEnumerable<Type> types);

            var planos = result.Get<Plano>();
            var beneficiarios = result.Get<Beneficiario>();
            var beneficiarioPlanos = result.Get<BeneficiarioPlano>();
            _planoRepository.Insert(planos);

            return result;
        }
    }
}
