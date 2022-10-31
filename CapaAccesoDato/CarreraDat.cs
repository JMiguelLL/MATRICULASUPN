using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDato
{
    public class CarreraDat
    {
        private static readonly CarreraDat carreraDat = new CarreraDat();
        public static CarreraDat Instancia
        {
            get
            {
                return CarreraDat.carreraDat;
            }
        }

       
    }
}
