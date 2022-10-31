using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Clase
    {

        public int idClase { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public int idCurso { get; set; }
        public int idAula { get; set; }
        public int status { get; set; }

        public Curso curso { get; set; }
        public Aula aula { get; set; }

    }
}
