using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logica
{
    public class clsMunicipio
    {
      
        //Jhon A
        public DataTable dtMunicipios(byte idDpto)
        {
            return new Datos.clsMunicipio().ListarMunicipios(idDpto);
        }
    }
}
