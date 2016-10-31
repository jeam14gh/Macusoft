using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logica
{
    public class clsSucursal
    {

        Comun.clsSucursal oCSucursal = new Comun.clsSucursal();
        Datos.clsSurculsal oDSucursal = new Datos.clsSurculsal();

        public bool Registrar_Sucursal(string Nombre_sucursal, string tele, string direccion)
        {
          
            oCSucursal.Nombre_sucursal = Nombre_sucursal;
            oCSucursal.Telefono_sucursal = tele;
            oCSucursal.Direccion_sucursal = direccion;

            return oDSucursal.Registrar_surcurlsale(oCSucursal);
        }


        public DataTable ListarSucursal()
        {
            Datos.clsSurculsal oclsSurculsal = new Datos.clsSurculsal();
            return oclsSurculsal.ListarSucursal();
        }


        public DataTable ConsultarSucursal(string nombre)
        {
            oCSucursal.Nombre_sucursal = nombre;


            return oDSucursal.ConsultarSucursal(oCSucursal);
        }

        public bool Actualizar_Sucursal(int id_sucursal, string Nombre_sucursal, string tele, string direccion)
        {
            oCSucursal.Id_sucursal = id_sucursal;
            oCSucursal.Nombre_sucursal = Nombre_sucursal;
            oCSucursal.Telefono_sucursal = tele;
            oCSucursal.Direccion_sucursal = direccion;

            return oDSucursal.ActualizarSucursales(oCSucursal);
        }
    }
}
