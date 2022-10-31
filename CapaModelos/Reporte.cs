using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Reporte
    {
        public int idMatricula { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombrePeriodo { get; set; }
        public int cursosMatriculados { get; set; }
        public int cantidadAgregados { get; set; }
        public int cantidadEliminados { get; set; }
    }
}
