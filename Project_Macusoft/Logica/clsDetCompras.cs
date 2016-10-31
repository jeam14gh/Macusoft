using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class clsDetCompras
    {
        //Llamamos la Capa Comun y la de datos
        Comun.clsDetCompra CoDetallesComp = new Comun.clsDetCompra();
        Datos.clsDetCompras DoDetallesComp = new Datos.clsDetCompras();

        public bool RegistrarDetallesCompra(string CodProd, int cant, int val)
        {

            CoDetallesComp.Cod_producto = CodProd;
            CoDetallesComp.Cantidad = cant;
            CoDetallesComp.Valor = val;

            return DoDetallesComp.Registrar_Detalles(CoDetallesComp);
 
        }

    }
}
