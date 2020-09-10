using CB.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CB.WebApp.MVC.Services
{
    public class AutenticacaoService : BaseService, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        private const string URL_REGISTRAR = "api/identidade/registrar";
        private const string URL_AUTENTICAR = "api/identidade/autenticar";
        public AutenticacaoService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:44398/");
        }

        public async Task<UsuarioResponseLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = GetContent(usuarioLogin);

            var response = await _httpClient.PostAsync(URL_AUTENTICAR, loginContent);

            if (!IsResponseValido(response))
            {
                return new UsuarioResponseLogin
                {
                    Erros = await Deserialize<ErrosResponse>(response)
                };
            }

            var retorno = await Deserialize<UsuarioResponseLogin>(response);

            return retorno;
        }

        public async Task<UsuarioResponseLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = GetContent(usuarioRegistro);

            var response = await _httpClient.PostAsync(URL_REGISTRAR, registroContent);

            if (!IsResponseValido(response))
            {
                return new UsuarioResponseLogin
                {
                    Erros = await Deserialize<ErrosResponse>(response)
                };
            }

            var retorno = await Deserialize<UsuarioResponseLogin>(response);

            return retorno;
        }
    }
}
