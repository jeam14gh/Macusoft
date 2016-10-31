using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsVentasDetalle
    {
        private string cod_Product;
        private int cantidad;
        private int valor;

        #region GET Y SET
        public string Cod_Product
        {
            get { return cod_Product; }
            set { cod_Product = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        #endregion

        public clsVentasDetalle() { }

        public clsVentasDetalle(string cod, int cant, int val)
        {
            this.Cod_Product = cod;
            this.Cantidad = cant;
            this.Valor = val;
        }
    }
}

