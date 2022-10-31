using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int intentos { get; set; }
        public int status { get; set; }

        public Usuario() { }
        public Usuario(int intentos, int status) {
            this.intentos = intentos;
            this.status = status;

        }
    }
}
