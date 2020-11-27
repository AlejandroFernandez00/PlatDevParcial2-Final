using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial2Dev.Models;
using Parcial2Dev.Modelo;
using ORM_MySQL;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Session;
using Parcial2Dev.DAOs;

namespace Parcial2Dev.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {

            string name = HttpContext.Session.GetString("Name");
            if (name != null)
            {
                return Redirect("/Home/Private");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult BuscarUsuarioConAjax([FromBody] Usuario jsonUsuario)
        {

            // Busco usuario en DAO por DB
            Usuario usuario = UsuarioDAO.getInstancia().getUsuarioporID(jsonUsuario.id);

            var jsonResult = JsonConvert.SerializeObject(usuario);

            return Json(jsonResult);

        }

        [HttpPost]
        public IActionResult Login(string usuariol, string password)
        {
            // Exite el usuario y pass ingresado con el de la base de datos?
            var usuarioEncontrado = UsuarioDAO.getInstancia().BuscarUsuario(usuariol, password);


            if (usuarioEncontrado != null)
            {
                //Existe! -> Confirmalo
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuarioEncontrado));

                return Redirect("/Home/Private");

            }
            else
            {

                ViewBag.msg = "El usuario no existe";
                return View("Index");
            }
        }


        [HttpPost]

        public IActionResult Register(string usuariof, string password,string serial)
        {

            using (var context = new DB())
            {
                //Existe algún serial? Traelo
                var serialEncontrado = UsuarioDAO.getInstancia().buscarSerial(serial);

                if (serialEncontrado != null)
                {
                    //Hay serial! -> Confirmalo para poder usarse.
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(serialEncontrado));

                    var usuario = new Usuario();
                    usuario.user = usuariof;
                    usuario.pass = password;
                    context.usuarios.Add(usuario); //Usuario creado, borremos el serial.
                    var serialABorrar = context.seriales.Single(x => x.nombreserial == serial);
                    context.seriales.Remove(serialABorrar);
                    context.SaveChanges(); //Guardar
                    

                    ViewBag.msg = "Su usuario fue creado con éxito!";
                    return View("Index");
                }
                ViewBag.msg = "La cuenta NO fue creada, utilice un serial válido.";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }

        public IActionResult Private()
        {

            var usuarioJson = HttpContext.Session.GetString("usuario");

            if (usuarioJson != null)
            {

                var usuario = JsonConvert.DeserializeObject<dynamic>(usuarioJson);

                ViewBag.usuario = usuario;
                return View("Private");

            }
            else
            {
                return View("Index");
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}