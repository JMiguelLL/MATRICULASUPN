using CapaLogica;
using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Matriculas.Models.Enum;

namespace Matriculas.Controllers
{

    public class EstudiantesController : BaseController
    {
        // GET: Estudiantes
        public ActionResult List()
        {
            List<Estudiante> listado = EstudianteLog.Instancia.ListaEstudiantes();
            return View(listado);
        }


        [HttpGet]
        public ActionResult CursosMatriculados(int idEstudiante)
        {
            Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudiante(idEstudiante);
            if (estudiante != null)
            {
                Matricula matricula = MatriculaLog.Instancia.BuscarMatriculaActivaEstudiante(idEstudiante);

                if (matricula == null)
                {
                    Alert("El estudiante no se ha matriculado en ningún curso", NotificationType.warning);
                    return RedirectToAction("List", "Estudiantes");
                }

                List<Clase> listaCursosMatriculados = ClaseLog.Instancia.CursosMatriculados(matricula.idMatricula);

                ViewData["estudiante"] = estudiante;
                ViewData["matricula"] = matricula;

                return View(listaCursosMatriculados);
            }

            Alert("El estudiante seleccionado no está activo", NotificationType.error);
            return RedirectToAction("List", "Estudiantes");

        }



    }
}
