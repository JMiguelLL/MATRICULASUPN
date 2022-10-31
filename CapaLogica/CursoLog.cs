using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CursoLog
    {
        private static readonly CursoLog cursoLog = new CursoLog();
        public static CursoLog Instancia
        {
            get
            {
                return cursoLog;
            }
        }

        public List<Curso> ListaCursosCarreraPeriodo(int idCarrera, int idPeriodo)
        {
            List<Curso> lista = CursosDat.Instancia.ListaCursosCarreraPeriodo(idCarrera, idPeriodo);

            return lista;
        }

        public Curso BuscarCurso(int idCurso)
        {
            return CursosDat.Instancia.BuscarCurso(idCurso);

        }
        public Curso BuscarCursoMatricula(int idMatricula, int idCurso)
        {
            return CursosDat.Instancia.BuscarCursoMatricula(idMatricula, idCurso);

        }
        public Curso BuscarCursoAnterior(int idCurso, int idEstudiante)
        {
            return CursosDat.Instancia.BuscarCursoAnterior(idCurso, idEstudiante);

        }

    }
}
