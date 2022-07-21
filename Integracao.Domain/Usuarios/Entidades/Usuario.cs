using System;
namespace Integracao.Domain.Usuarios.Entidades
{
	public class Usuario
	{
        public string Nome { get; set; }
        public string Senha { get; set; }

        public static Usuario UsuarioUnico = new()
        {
            Nome = "Int.Sul.Import",
            Senha = "Sul.21@07/Imp"
        };
    }
}

