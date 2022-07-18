using Integracao.Conversores.Base.Interfaces;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Sul_America
{
    public class SulAmericaConverter : IOperadoraConverter
    {

        

        public void IdentificaArquivo(string arquivo)
        {

        }

        Func<Stream, IEnumerable<EntityBase>> IOperadoraConverter.IdentificaArquivo(string arquivo)
        {
            throw new NotImplementedException();
        }
    }
}
