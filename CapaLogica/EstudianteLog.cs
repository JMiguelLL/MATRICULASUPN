using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class EstudianteLog
    {
        private static readonly EstudianteLog estudianteLog = new EstudianteLog();
        public static EstudianteLog Instancia
        {
            get
            {
                return estudianteLog;
            }
        }

        public List<Estudiante> ListaEstudiantes()
        {
            List<Estudiante> lista = EstudianteDat.Instancia.ListaEstudiantes();

            return lista;
        }
        public Estudiante BuscarEstudiante(int idEstudiante)
        {
            return EstudianteDat.Instancia.BuscarEstudiante(idEstudiante);

        }
        public Estudiante BuscarEstudianteCarrera(int idEstudiante)
        {
            return EstudianteDat.Instancia.BuscarEstudianteCarrera(idEstudiante);

        }
    }
}
