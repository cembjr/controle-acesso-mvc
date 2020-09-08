using CB.ControleLogin.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.ControleLogin.WebApp.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioResponseLogin> Login(UsuarioLogin usuarioLogin);

        Task<UsuarioResponseLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
