using Integracao.Conversores.Base.Interfaces;
using Integracao.Conversores.Sul_America;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Conversores
{
    public class ConverterFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ConverterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //enum de operadoras
        public IOperadoraConverter Config(OperadoraEnum operadora)
        {
            return (IOperadoraConverter)_serviceProvider.GetService(operadora switch
            {
                OperadoraEnum.SulAmerica => typeof(SulAmericaConverter),
              
                _ => throw new NotImplementedException()
            });
        }

    }
}
