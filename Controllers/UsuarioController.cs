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
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usu)
        {

            UsuarioRepository al = new UsuarioRepository();
            al.Inserir(usu);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!!!";

            return View();
        }

        public IActionResult Lista()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository al = new UsuarioRepository();
            List<Usuario> listagemDeUsuarios = al.Listar();
            return View(listagemDeUsuarios);
        }

        public IActionResult Remover(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository al = new UsuarioRepository();
            Usuario usuarioLocalizado = al.BuscarPorId(Id);
            al.Excluir(usuarioLocalizado);
            return RedirectToAction("Lista", "Usuario");
        }

        public IActionResult Editar(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository al = new UsuarioRepository();
            Usuario usuarioLocalizado = al.BuscarPorId(Id);
            return View(usuarioLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usu)
        {

            UsuarioRepository al = new UsuarioRepository();
            al.Alterar(usu);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!!!";
            return RedirectToAction("Lista", "Usuario");
        }

         public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usu)
        {
            UsuarioRepository al = new UsuarioRepository();

            Usuario usuarioEncontrado = al.ValidarLogin(usu);

            if(usuarioEncontrado == null)
            {
                ViewBag.Mensagem = "Email ou Senha incorretos";
                return View();

            }else{
                
                HttpContext.Session.SetInt32("IdUsuario", usuarioEncontrado.Id);
                HttpContext.Session.SetString("EmailUsuario", usuarioEncontrado.Email);

                return RedirectToAction("Lista", "Usuario");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}