using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaAccesoDato
{
    public class UsuarioDat
    {
        private static readonly UsuarioDat usuarioDat = new UsuarioDat();
        public static UsuarioDat Instancia
        {
            get
            {
                return UsuarioDat.usuarioDat;
            }
        }

        public Usuario ValidarLogin(Usuario usuario)
        {
            Usuario usuarioBase = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("validarLogin", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@paramEmail", usuario.email);
                cmd.Parameters.AddWithValue("@paramPassword", usuario.password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuarioBase = new Usuario
                    {
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        email = Convert.ToString(dr["email"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]),
                        intentos = Convert.ToInt32(dr["intentos"]),
                    };
                }
                cn.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarioBase;
        }


        public Usuario BuscarUsuario(string email)
        {
            Usuario usuarioBase = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarUsuario", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@paramEmail", email);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuarioBase = new Usuario
                    {
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                    };
                }
                cn.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarioBase;
        }
        public void SumarIntento(String email)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("sumarIntento", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@paramEmail", email);
                cn.Open();
                cmd.ExecuteReader();
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        
        public Usuario ObtenerIntentos(String email)
        {
            Usuario usuarioEncontrado = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("obtenerIntentos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramEmail", email);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuarioEncontrado = new Usuario
                    {
                        intentos = Convert.ToInt32(dr["intentos"]),
                        status = Convert.ToInt32(dr["status"]),
                    };
                   
                }
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarioEncontrado;
        }
        public void BloquearAcceso(String email)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("bloquearAcceso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramEmail", email);
                cn.Open();

                cmd.ExecuteReader();
               
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ReiniciarNumeroIntentos(String email)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();

                SqlCommand cmd = new SqlCommand("reiniciarNumeroIntentos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramEmail", email);

                cn.Open();

                cmd.ExecuteReader();

                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
