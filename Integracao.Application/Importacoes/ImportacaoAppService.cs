using Integracao.Conversores;
using Integracao.Domain.Apolices.Entities;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Application.Importacoes
{
    public class ImportacaoAppService
    {

        private readonly IManipulationRepository _manipulationRepository;
        private readonly ConverterFactory _converterFactory;
        public ImportacaoAppService(ConverterFactory converterFactory, IManipulationRepository manipulationRepository)
        {
            _converterFactory = converterFactory;
            _manipulationRepository = manipulationRepository;
        }

        public void ImportarArquivos(string nomeArquivo, Stream arquivo, OperadorasEnum operadora)
        {

            IEnumerable<Type> types = new List<Type>
            {
                typeof(Beneficiario),
                typeof(Apolice),
            };

            var objetos = _converterFactory
            .Config(operadora)
            .IdentificaArquivo(nomeArquivo)
            .Invoke(arquivo);

            foreach (var type in types)
            {
                var beneficiarios = objetos.Where(x => type.IsAssignableTo(x.GetType()));
                _manipulationRepository.Insert<Beneficiario>(beneficiarios as Beneficiario);
            }
        }
    }
}
