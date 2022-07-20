using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Infra;

namespace Integracao.Application.Importacoes
{
    public class ImportacaoAppService : IImportacaoAppService
    {

        private readonly IManipulationRepository _manipulationRepository;
        private readonly ConverterFactory _converterFactory;
        private readonly RepositoryFactory _repositoryFactory;

        public ImportacaoAppService(RepositoryFactory repositoryFactory, ConverterFactory converterFactory, IManipulationRepository manipulationRepository)
        {
            _converterFactory = converterFactory;
            _manipulationRepository = manipulationRepository;
            _repositoryFactory = repositoryFactory;
        }

        public void ImportarArquivos(string nomeArquivo, Stream arquivo, OperadorasEnum operadora)
        {

            IEnumerable<Type> types = new List<Type>
            {
                typeof(Beneficiario),
                typeof(Evento),

            };

            var objetos = _converterFactory
            .Config(operadora)
            .IdentificaArquivo(nomeArquivo)
            .Invoke(arquivo);

            foreach (var type in types)
            {
                var beneficiarios = objetos.Where(x => type.IsAssignableTo(x.GetType()));
                

            }
        }
    }
}
