using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class MatriculaDetalle
    {

        public int idMatriculaDetalle { get; set; }

        public int idClase { get; set; }
        public int idMatricula { get; set; }
        public int status { get; set; }
        public Clase clase { get; set; }
        public Matricula matricula { get; set; }
    }
}
