using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logica
{
   public class clsDetalles
    {
        Comun.clsDetalles Cdt = new Comun.clsDetalles();
        Datos.clsDetalles Ddt = new Datos.clsDetalles();
        public bool Registrar_detalles(string Cod, int Cant, int val)
        {
            Cdt.Cod_Product = Cod;
            Cdt.Cantidad = Cant;
            Cdt.Valor = val;
            return Ddt.Agregar_Detalles(Cdt);
        }
        public DataTable Consultar_Detalles()
        {
            return Ddt.Consultar_Detalles();
        }
        public bool Agregar_Detalles(string Cod, int Cant, int val)
        {
            Cdt.Cod_Product = Cod;
            Cdt.Cantidad = Cant;
            Cdt.Valor = val;
            return Ddt.Registrar_Detalles(Cdt);
        }
        public bool Elimina_Detalles()
        {
            return Ddt.Eliminar_Detalles();
        }

        public bool Eliminar_Detalles(string cod)
        {
            Cdt.Cod_Product = cod;
            return Ddt.Eliminar_Detalle(Cdt);
        }
    }
}
