using Integracao.Core.Base.Entities;
using System;
namespace Integracao.Domain.Usuarios.Entidades
{
	public class Usuario : EntityBase
	{
        public virtual string Nome { get; set; }
        public virtual string Senha { get; set; }

        public static Usuario UsuarioUnico = new()
        {
            Nome = "Int.Sul.Import",
            Senha = "Sul.21@07/Imp"
        };
    }
}

