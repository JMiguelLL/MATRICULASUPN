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
    public class MatriculaController : BaseController
    {
       
        [HttpGet]
        public ActionResult Periodo(int idEstudiante)
        {
            Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudiante(idEstudiante);
            if(estudiante != null)
            {
                List<Periodo> listaPeriodos = PeriodoLog.Instancia.ListaPeriodosActivos();
                ViewBag.listaPeriodos = new SelectList(listaPeriodos, "idPeriodo", "nombre");
                return View(estudiante);
            }
            Alert("El estudiante seleccionado no está activo", NotificationType.error);
            return RedirectToAction("List", "Estudiantes");
           
        }


        // POST: Matricula/Create
        [HttpPost]
        public ActionResult Periodo(int idEstudiante, FormCollection form)
        {
            
            try
            {
                int idPeriodo = Convert.ToInt32(form["periodoElegido"]);

                return RedirectToAction("CursosPeriodo", "Matricula", new { idEstudiante, idPeriodo });
            }
            catch
            {
                return RedirectToAction("List", "Estudiantes");
            }

        }

        [HttpGet]
        public ActionResult CursosPeriodo(int idEstudiante, int idPeriodo)
        {
            Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudianteCarrera(idEstudiante);
            Periodo periodo = PeriodoLog.Instancia.BuscarPeriodo(idPeriodo);

            if (estudiante != null && periodo != null )
            {
                if(periodo.status == 1)
                {
                    List<Curso> listaCursos = CursoLog.Instancia.ListaCursosCarreraPeriodo(estudiante.idCarrera, periodo.idPeriodo);

                    ViewData["estudiante"] = estudiante;
                    ViewData["periodo"] = periodo;
                    if (listaCursos.Count() == 0)
                    {
                        Alert("No hay cursos disponibles para este periodo", NotificationType.error);
                    }
                    return View(listaCursos);
                }
                if (periodo.status == 2)
                {
                    Alert("El periodo ha finalizado", NotificationType.error);
                }
                if (periodo.status == 0)
                {
                    Alert("El periodo no está activo aún", NotificationType.error);
                }
                return RedirectToAction("List", "Estudiantes");
            }
                
            Alert("Hubo un error al cargar los datos", NotificationType.error);

            return RedirectToAction("List", "Estudiantes");

        }

        [HttpGet]
        public ActionResult ClasesCurso(int idEstudiante, int idPeriodo, int idCurso)
        {
         
            Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudianteCarrera(idEstudiante);
            Periodo periodo = PeriodoLog.Instancia.BuscarPeriodo(idPeriodo);
            Curso curso = CursoLog.Instancia.BuscarCurso(idCurso);

            if (estudiante != null && periodo != null && curso != null)
            {
                Matricula matricula = MatriculaLog.Instancia.BuscarMatriculaEstudiante(idEstudiante, idPeriodo);

                if(matricula != null)
                {
                    //BUSCAR CURSO YA REGISTRADO
                    Curso cursoRegistrado = CursoLog.Instancia.BuscarCursoMatricula(matricula.idMatricula, idCurso);

                    if (cursoRegistrado != null)
                    {
                        Alert("El estudiante ya ha sido registrado en este curso", NotificationType.error);
                        return RedirectToAction("CursosPeriodo", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo });
                    }
                }

                //REVISAR QUE NO HAYA LLEVADO EL CURSO
                Curso cursoHistorico = CursoLog.Instancia.BuscarCursoAnterior(curso.idCurso, estudiante.idEstudiante);

                if(cursoHistorico != null)
                {
                    Alert("El estudiante ya tomó el curso con anterioridad", NotificationType.error);
                    return RedirectToAction("CursosPeriodo", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo });
                }

                List<Clase> listaClases = ClaseLog.Instancia.ListaClasesCurso(curso.idCurso);

                ViewData["estudiante"] = estudiante;
                ViewData["periodo"] = periodo;
                ViewData["curso"] = curso;

                if (listaClases.Count() == 0)
                {
                    Alert("No hay clases disponibles para el curso en este periodo", NotificationType.warning);
                }
                return View(listaClases);

            }

            Alert("Hubo un error al cargar los datos", NotificationType.error);

            return RedirectToAction("CursosPeriodo", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo});

        }
        [HttpGet]
        public ActionResult RegistrarEstudianteClase(int idEstudiante, int idPeriodo, int idCurso, int idClase)
        {
            try
            {
                Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudianteCarrera(idEstudiante);
                Periodo periodo = PeriodoLog.Instancia.BuscarPeriodo(idPeriodo);
                Curso curso = CursoLog.Instancia.BuscarCurso(idCurso);
                Clase clase = ClaseLog.Instancia.BuscarClase(idClase);

                if (estudiante != null && periodo != null && curso != null && clase != null)
                {
                    Matricula matricula = MatriculaLog.Instancia.BuscarMatriculaEstudiante(idEstudiante, idPeriodo);


                    if (matricula == null)
                    {
                        Matricula newMatricula = new Matricula
                        {
                            fechaMatricula = DateTime.Now,
                            idEstudiante = idEstudiante,
                            idPeriodo = idPeriodo,
                            status = 1
                        };

                        matricula = MatriculaLog.Instancia.NuevaMatricula(newMatricula);

                    }


                    MatriculaDetalle matriculaDetalle = new MatriculaDetalle
                    {
                        idMatricula = matricula.idMatricula,
                        idClase = clase.idClase,
                        status = 1,
                    };


                    matriculaDetalle = MatriculaDetalleLog.Instancia.NuevaMatriculaDetalle(matriculaDetalle);

                    Usuario usuario = UsuarioLog.Instancia.BuscarUsuario((string)(Session["email"]));

                    LogsMatriculaDetalle logMatriculaDetalle = new LogsMatriculaDetalle
                    {
                        fechaRegistro = DateTime.Now,
                        accion = 1,//añadir curso
                        idMatriculaDetalle = matriculaDetalle.idMatriculaDetalle,
                        idUsuario = usuario.idUsuario,
                    };

                    LogsMatriculaDetalleLog.Instancia.NuevoLogMatriculaDetalle(logMatriculaDetalle);

                    Alert("Se registró al estudiante con código " + estudiante.codigo + " en el curso " + curso.nombre, NotificationType.success);

                    return RedirectToAction("List", "Estudiantes");

                }
            }
            catch
            {
                Alert("Hubo un error al hacer el registro", NotificationType.error);
            }
                      
            return RedirectToAction("ClasesCurso", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo, idCurso = idCurso });

        }
        
        [HttpGet]
        public ActionResult NoPermitido()
        {

            Alert("El estudiante seleccionado no está activo", NotificationType.error);
            return RedirectToAction("List", "Estudiantes");

        }



        [HttpGet]
        public ActionResult EditarMatricula(int idEstudiante)
        {
            Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudiante(idEstudiante);
            if (estudiante != null)
            {
                Matricula matricula = MatriculaLog.Instancia.BuscarMatriculaActivaEstudiante(idEstudiante);

                if(matricula == null)
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


        [HttpGet]
        public ActionResult EliminarCurso(int idEstudiante, int idMatricula, int idClase)
        {
            try
            {
                Estudiante estudiante = EstudianteLog.Instancia.BuscarEstudiante(idEstudiante);
                if (estudiante != null)
                {
                    MatriculaDetalle matriculaDetalle = MatriculaDetalleLog.Instancia.BuscarDetalleClase(idMatricula, idClase);

                    if (matriculaDetalle == null)
                    {
                        Alert("Hubo un problema al quitar el curso", NotificationType.error);
                        return RedirectToAction("EditarMatricula", "Matricula", new { idEstudiante = idEstudiante });
                    }

                    MatriculaDetalleLog.Instancia.EliminarCursoMatriculado(matriculaDetalle.idMatriculaDetalle);


                    Usuario usuario = UsuarioLog.Instancia.BuscarUsuario((string)(Session["email"]));

                    LogsMatriculaDetalle logMatriculaDetalle = new LogsMatriculaDetalle
                    {
                        fechaRegistro = DateTime.Now,
                        accion = 2,//eliminar curso
                        idMatriculaDetalle = matriculaDetalle.idMatriculaDetalle,
                        idUsuario = usuario.idUsuario,
                    };

                    LogsMatriculaDetalleLog.Instancia.NuevoLogMatriculaDetalle(logMatriculaDetalle);

                    Alert("Se quito correctamente al estudiante del curso", NotificationType.success);
                    return RedirectToAction("EditarMatricula", "Matricula", new { idEstudiante = idEstudiante });
                }

                Alert("El estudiante seleccionado no está activo", NotificationType.error);
               
            }
            catch
            {
                Alert("Hubo un problema al quitar el curso", NotificationType.error);
            }

            return RedirectToAction("List", "Estudiantes");
        }
    }
}
