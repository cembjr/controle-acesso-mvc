using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CB.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CB.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool HasResponseErros(ErrosResponse erros)
        {
            if (erros == null || (erros != null && !erros.Erros.Any())) return false;

            foreach (var mensagem in erros.Erros)
                ModelState.AddModelError(string.Empty, mensagem);
            
            return true;
        }
    }
}
