using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }

        public string codigo { get; set; }
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

        public string telefono { get; set; }

        public int idCarrera { get; set; }

        public int status { get; set; }

        public Carrera carrera { get; set; }
    }
}
