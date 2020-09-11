using CB.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CB.WebApp.MVC.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public ProdutoService(HttpClient httpClient) : base(httpClient, new Uri("https://localhost:44305/")) { }

        public async Task<IList<ProdutoViewModel>> ListarAsync()
        {
            var produtos = await GetListAsync<ProdutoViewModel>("/api/produtos/listar-produtos");
            return produtos.Result;
        }

        public async Task<bool> AdicionarProduto(AdicionarProdutoViewModel produto)
        {
            var result = await Post(produto, "api/produtos/adicionar-novo-produto");
            return result;
        }

        public async Task<bool> Atualizar(ProdutoViewModel produto)
        {
            var result = await Put(produto, "/api/produtos/editar-produto");
            return result;
        }

        public async Task<ProdutoViewModel> Obter(Guid id)
        {
            var result = await GetAsync<ProdutoViewModel>($"/api/produtos/obter-produto/{id}");
            return result.Result;
        }
    }
}
