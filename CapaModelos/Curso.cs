using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Curso
    {

        public int idCurso { get; set; }
        public string nombre { get; set; }
        public int creditos { get; set; }
        public int status { get; set; }
        public int idCarrera { get; set; }
        public int idPeriodo { get; set; }
        public Carrera carrera { get; set; }
        public Periodo periodo { get; set; }
    }
}
