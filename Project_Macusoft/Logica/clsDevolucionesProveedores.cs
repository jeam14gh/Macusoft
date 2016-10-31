using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsDevolucionesProveedores
    {

        Comun.clsDevolucionesProveedores CmDevPro = new Comun.clsDevolucionesProveedores();
        Datos.clsDevolucionesProveedores DtDevPro = new Datos.clsDevolucionesProveedores();
        public bool Regitrar_Devoluciones(string a, string b, int d)
        {
            CmDevPro.Documento_Proveedor = a;
            CmDevPro.Motivos = b;
            CmDevPro.ID_Tipo_Movimiento = d;
            return DtDevPro.RegistrarDevProv(CmDevPro);
        }

        public DataTable Consultar(string nit, string co)
        {
            return DtDevPro.Consultar_Decoluciones_Proveedores(nit, co);
        }
     }
}
