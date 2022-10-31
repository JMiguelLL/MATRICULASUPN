using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Matricula
    {

        public int idMatricula { get; set; }

        public DateTime fechaMatricula { get; set; }

        public int idEstudiante { get; set; }
        public int idPeriodo { get; set; }
        public int status { get; set; }

        public Estudiante estudiante { get; set; }
        public Periodo periodo { get; set; }
    }
}
