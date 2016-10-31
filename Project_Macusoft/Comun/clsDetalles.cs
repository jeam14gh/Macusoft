using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
   public class clsDetalles
    {
        private string cod_Product;

        public string Cod_Product
        {
            get { return cod_Product; }
            set { cod_Product = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public clsDetalles()
        {
        }
        public clsDetalles(string cod, int cant, int val)
        {
            this.Cod_Product = cod;
            this.Cantidad = cant;
            this.Valor = val;
        }

        /// <summary>
        /// Constructor para agregar el detalle de una comida
        /// </summary>
        public clsDetalles(string codProd, int cant)
        {
            this.Cod_Product = codProd;
            this.Cantidad = cant;
        }
    }
}
