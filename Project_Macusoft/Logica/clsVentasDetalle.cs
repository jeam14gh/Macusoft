using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logica
{
    public class clsVentasDetalle
    {
        Comun.clsVentasDetalle CoVenDet;
        Datos.clsVentasDetalle DoVenDet = new Datos.clsVentasDetalle();

        public bool RegistrarDetallesVenta(string CodProd, int cant, int val) 
        {
            CoVenDet=new Comun.clsVentasDetalle(CodProd, cant, val);
            return DoVenDet.RegistrarDetalles(CoVenDet);
        }

        //public bool Recorrer_Ingresar_Detalles_Servicio()
        //{
        //    //bool respuestaDetallesVenta = false;

        //    //AccesoDatos.ClsDetallesServicio InsClsDttServicios = new AccesoDatos.ClsDetallesServicio();

        //    //respuestaDetallesVenta = DoVenDet.RegistrarDetallesVenta();

        //    //return respuestaDetallesVenta;
        //}


    }
}
