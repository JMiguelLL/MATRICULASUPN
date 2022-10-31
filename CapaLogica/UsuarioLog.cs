using CapaModelos;
using CapaAccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class UsuarioLog
    {

        private static readonly UsuarioLog usuarioLog = new UsuarioLog();
        public static UsuarioLog Instancia
        {
            get
            {
                return usuarioLog;
            }
        }

        public Usuario ValidarLogin(Usuario usuario)
        {
            if (usuario.email == null) 
                usuario.email = "";
            if (usuario.password == null) 
                usuario.password = "";

            Usuario usuarioBase = UsuarioDat.Instancia.ValidarLogin(usuario);

            if (usuarioBase != null)
            {
                UsuarioDat.Instancia.ReiniciarNumeroIntentos(usuario.email);
            }

            return usuarioBase;
        }
        public Usuario BuscarUsuario(string email)
        {
            return UsuarioDat.Instancia.BuscarUsuario(email);
        }

        public void SumarIntento(String email)
        {
            if (email == null) email = "";

            UsuarioDat.Instancia.SumarIntento(email);
        }

        public void BloquearAcceso(String email)
        {
            if (email == null) email = "";

            UsuarioDat.Instancia.BloquearAcceso(email);
        }
        public Usuario ObtenerIntentos(String email)
        {
            if (email == null) email = "";

            return UsuarioDat.Instancia.ObtenerIntentos(email);
        }
        public void ReiniciarNumeroIntentos(String email)
        {

            UsuarioDat.Instancia.ReiniciarNumeroIntentos(email);
        }

        
    }
}
