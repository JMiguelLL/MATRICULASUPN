using CapaModelos;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Matriculas.Models.Enum;

namespace Matriculas.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {

            //VALIDAR NUMERO DE INTENTOS
            Usuario usuarioIntentosStatus = UsuarioLog.Instancia.ObtenerIntentos(usuario.email);

            if(usuarioIntentosStatus == null)
            {
                Alert("El email ingresado no está registrado", NotificationType.error);
                ViewBag.Message = "El email ingresado no está registrado";
                return View();
            }

            if (usuarioIntentosStatus.intentos > 2)
            {
                if (usuarioIntentosStatus.status != 2)
                {
                    UsuarioLog.Instancia.BloquearAcceso(usuario.email);
                }
                Alert("Excedió el número de intentos permitidos", NotificationType.error);
                ViewBag.Message = "Excedió el número de intentos permitidos";
                return View();
            }

            if(usuarioIntentosStatus.status == 2)
            {
                Alert("La cuenta fue bloqueada por exceder el número de intentos", NotificationType.error);
                ViewBag.Message = "La cuenta fue bloqueada por exceder el número de intentos";
                return View();
            }

            //VALIDAR EMAIL Y CONTRASEÑA CORRECTOS
            Usuario usuarioEncontrado = UsuarioLog.Instancia.ValidarLogin(usuario);
            
            if(usuarioEncontrado == null)
            {
                UsuarioLog.Instancia.SumarIntento(usuario.email);
                ViewBag.Message = "La contraseña y/o email no coinciden. Quedan " + (2 - usuarioIntentosStatus.intentos) + " intentos";
                return View();
            }

            DateTime fecha = DateTime.Now;

            LogsUsuario newLogUsuario = new LogsUsuario(usuarioEncontrado.idUsuario, fecha);
            LogsUsuarioLog.Instancia.NuevoLogUsuario(newLogUsuario);

            UsuarioLog.Instancia.ReiniciarNumeroIntentos(usuario.email);

            Session["idUsuario"] = usuarioEncontrado.idUsuario;
            Session["email"] = usuarioEncontrado.email;
            Session["nombre"] = usuarioEncontrado.nombre;
            Session["apellido"] = usuarioEncontrado.apellidoPaterno;
            return RedirectToAction("Index", "Home");
        }

    }
}
