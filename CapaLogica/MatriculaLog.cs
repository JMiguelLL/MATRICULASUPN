using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class MatriculaLog
    {
        private static readonly MatriculaLog matriculaLog = new MatriculaLog();
        public static MatriculaLog Instancia
        {
            get
            {
                return matriculaLog;
            }
        }

        public Matricula BuscarMatriculaEstudiante(int idEstudiante, int idPeriodo)
        {
            return MatriculaDat.Instancia.BuscarMatriculaEstudiante(idEstudiante, idPeriodo);

        }

        public Matricula NuevaMatricula(Matricula matricula)
        {
            return MatriculaDat.Instancia.NuevaMatricula(matricula);
        }

        public Matricula BuscarMatriculaActivaEstudiante(int idEstudiante)
        {
            return MatriculaDat.Instancia.BuscarMatriculaActivaEstudiante(idEstudiante);
        }
    }
}
