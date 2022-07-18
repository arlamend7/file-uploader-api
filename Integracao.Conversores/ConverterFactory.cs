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
        public IOperadoraConverter Config(OperadorasEnum operadora)
        {
            return (IOperadoraConverter)_serviceProvider.GetService(operadora switch
            {
                OperadorasEnum.SulAmerica => typeof(SulAmericaConverter),
              
                _ => throw new NotImplementedException()
            });
        }

    }
}
