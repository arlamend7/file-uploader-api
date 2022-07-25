using Integracao.Application.Importacoes.DatasTransfer.Requests;
using Integracao.Application.Importacoes.DatasTransfer.Responses;
using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores;
using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Interfaces;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Domain.Planos.Entidades;
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

        private FileConverterResult ConvertFile(Stream arquivo, FileImportInsertRequest request, Importacao import = null)
        {
            IOperadoraFileConverter operadoraFileConverter = _converterFactory
                                .Config(request.Operadora)
                                .IdentificaArquivo(request.Classe);


            return operadoraFileConverter.Convert(arquivo, import);
        }

        public Guid InsertValuesFile(string fileName, Stream arquivo, FileImportInsertRequest request)
        {
            Importacao entity = new(fileName, arquivo.Length, request.Classe, request.Operadora, request.Month, request.Year);
            var id = _manipulationRepository.Insert(entity);
            entity.SetId(id);

            IOperadoraFileConverter operadoraFileConverter = _converterFactory
                              .Config(request.Operadora)
                              .IdentificaArquivo(request.Classe);
            var result = operadoraFileConverter.Convert(arquivo, entity);

            foreach (var type in operadoraFileConverter.OutTypes)
            {
                _repositoryFactory.Config(type).Insert(result.Get(type), request.Operadora);
            }
            

            return entity.Identifier;
        }

        public FileConverterResultResponse ValidateFile(Stream arquivo, FileImportInsertRequest request)
        {
            IOperadoraFileConverter operadoraFileConverter = _converterFactory
                                          .Config(request.Operadora)
                                          .IdentificaArquivo(request.Classe);
            var result = operadoraFileConverter.Convert(arquivo, null);
            return new FileConverterResultResponse()
            {
                Rows = result.Rows.Select(row => new FileTypeRowConvertResultResponse()
                {
                    Cells = row.Cells.Select(cell => {

                        var property = cell.GetType().GetProperty("ErrorMessage");

                        string meesage = null;
                        if (!cell.Success)
                             meesage = property.GetValue(cell).ToString();

                        return new FileColumnConvertResultResponse()
                        {
                            Column = cell.Column,
                            HasValue = cell.HasValue,
                            Property = cell.Property,
                            Success = cell.Success,
                            TypeName = cell.TypeName,
                            Value = cell.Value,
                            ErrorMessage = meesage
                        };
                    }),
                    Error = row.Error,
                    Line = row.Line,
                    TypeName = row.TypeName
                }),
                Sucesso = result.Sucesso
            };
        }
    }
}
