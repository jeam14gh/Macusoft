using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsDevolucionesProveedores
    {
        private string documento_Proveedor;
        private string motivos;
        private int iD_Tipo_Movimiento;
        private int id_Movimiento_Novedad;

        public string Documento_Proveedor
        {
            get { return documento_Proveedor; }
            set { documento_Proveedor = value; }
        }

        public string Motivos
        {
            get { return motivos; }
            set { motivos = value; }
        }

        public int ID_Tipo_Movimiento
        {
            get { return iD_Tipo_Movimiento; }
            set { iD_Tipo_Movimiento = value; }
        }

        public int Id_Movimiento_Novedad
        {
            get { return id_Movimiento_Novedad; }
            set { id_Movimiento_Novedad = value; }
        }

        public clsDevolucionesProveedores()
        {
        }
        public clsDevolucionesProveedores(string pro, string moti, int tip, int mo)
        {
            this.Documento_Proveedor = pro;
            this.Motivos = moti;
            this.Id_Movimiento_Novedad = mo;
            this.ID_Tipo_Movimiento = tip;
        }

    }
}
