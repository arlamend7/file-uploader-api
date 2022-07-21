using System;
using Integracao.Conversores.Base.Entities;

namespace Integracao.Conversores.Base.Delegates
{
    public delegate FileConverterResult FileConvert(Stream file, out IEnumerable<Type> types);
}

