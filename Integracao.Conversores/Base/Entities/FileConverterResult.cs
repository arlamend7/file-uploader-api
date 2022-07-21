using System;
using Integracao.Conversores.Base.Exceptions;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Base.Entities
{
	public class FileConverterResult
	{
        public List<EntityBase> Sucessos { get; set; }
        public List<FileConverterLineException> Erros { get; set; }
        public bool Sucesso => !Erros.Any();
        public FileConverterResult()
        {
            Sucessos = new List<EntityBase>();
            Erros = new List<FileConverterLineException>();
        }

        public IEnumerable<T> Get<T>() where T : EntityBase
        {
            return Sucessos.Where(x => x is T).Select(x => x as T);
        }

        public IEnumerable<object> Get(Type type)
        {
            return Sucessos.Where(x => type.IsAssignableTo(x.GetType()));
        }
    }

  
}

