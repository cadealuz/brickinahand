using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Brick_in_a_Hand.Models;
using Microsoft.AspNetCore.Http;

namespace Brick_in_a_Hand.Controllers 
{
    public class MercadoriasController : Controller
    {
        public IActionResult CadastroMercadorias()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroMercadorias(Mercadorias pac)
        {
            MercadoriasRepository al = new MercadoriasRepository();
            al.MercadoriasInserir(pac);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!!!";
            return View();
        }

        public IActionResult ListaMercadorias()
        {
           MercadoriasRepository al = new MercadoriasRepository();
            List<Mercadorias> listagemDeMercadorias = al.MercadoriasListar();
            return View(listagemDeMercadorias);
        }

        public IActionResult RemoverMercadorias(int Id)
        {
            MercadoriasRepository al = new MercadoriasRepository();
            Mercadorias MercadoriasEncontrado = al.BuscarPorId(Id);
            al.MercadoriasExcluir(MercadoriasEncontrado);
            return RedirectToAction("ListaMercadorias", "Mercadorias");
        }

        public IActionResult EditarMercadorias(int Id)
        {
            MercadoriasRepository al = new MercadoriasRepository();
            Mercadorias mercadoriasLocalizado = al.BuscarPorId(Id);
            return View(mercadoriasLocalizado);
        }

        [HttpPost]

        public IActionResult EditarMercadorias(Mercadorias pac)
        {
            MercadoriasRepository al = new MercadoriasRepository();
            al.MercadoriasAlterar(pac);
            return RedirectToAction("ListaMercadorias", "Mercadorias");
        }

        public IActionResult Action_Figures()
        {
            return View();
        }

        public IActionResult Carrinho()
        {
            return View();
        }
    }
}