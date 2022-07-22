using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores;
using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Infra;

namespace Integracao.Application.Importacoes
{
    public class ImportacaoAppService : IImportacaoAppService
    {
        private readonly IManipulationRepository _manipulationRepository;
        private readonly ConverterFactory _converterFactory;
        private readonly RepositoryFactory _repositoryFactory;

        public ImportacaoAppService(IManipulationRepository manipulationRepository, ConverterFactory converterFactory, RepositoryFactory repositoryFactory)
        {
            _converterFactory = converterFactory;
            _repositoryFactory = repositoryFactory;
            _manipulationRepository = manipulationRepository;
        }

        public FileConverterResult ImportarArquivos(string fileName, ClasseArquivoEnum nomeArquivo, Stream arquivo, OperadoraEnum operadora)
        {
            Importacao entity = new(fileName, arquivo.Length, nomeArquivo, operadora);

            _manipulationRepository.Insert(new Operadora(1, "SulAmerica"));
            _manipulationRepository.Insert(entity);


            FileConverterResult result = _converterFactory
                                .Config(operadora)
                                .IdentificaArquivo(nomeArquivo)
                                .Invoke(arquivo, out IEnumerable<Type> types);

            foreach (var type in types)
            {
                _repositoryFactory.Config(type).Insert(result.Get(type), operadora);
            }

            return result;
        }
    }
}
