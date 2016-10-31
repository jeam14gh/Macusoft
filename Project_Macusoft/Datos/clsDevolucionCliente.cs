using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
   public class clsDevolucionCliente
    {
       public bool RegistrarDevClien(Comun.clsDevolucionCliente DevClien)
       {
           bool res = false;
           SqlConnection Cn = new SqlConnection();
           try
           {
               Conexion con = new Conexion();
               Cn = con.slConexion();
               Cn.Open();
               string SP_RegistrarDevolucionesClientes = "SP_RegistrarDevolucionesCliente";
               SqlCommand CmdDevPro = new SqlCommand(SP_RegistrarDevolucionesClientes, Cn);
               CmdDevPro.CommandType = CommandType.StoredProcedure;
               CmdDevPro.Parameters.AddWithValue("@Nit_cliente", DevClien.Documento_cliente);
               CmdDevPro.Parameters.AddWithValue("@Motivos", DevClien.Motivos);
               CmdDevPro.Parameters.AddWithValue("@Dian", DevClien.Novedad);
               int Resultado = CmdDevPro.ExecuteNonQuery();
               if (Resultado > 0)
               {
                   res = true;
               }
           }
           catch (Exception e)
           {
               res = false;
           }
           finally
           {
               Cn.Close();
               Cn.Dispose();
           }
           return res;
       }
    }
}
