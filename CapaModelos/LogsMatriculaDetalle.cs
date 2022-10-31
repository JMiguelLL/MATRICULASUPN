using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class LogsMatriculaDetalle
    {

        public int idLogsMatriculaDetalle { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int accion { get; set; }
        public int idMatriculaDetalle { get; set; }
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }
        public MatriculaDetalle matriculaDetalle { get; set; }
        public LogsMatriculaDetalle()
        {
        }
    }
}
