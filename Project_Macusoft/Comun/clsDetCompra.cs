using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsDetCompra
    {
        //Atributos
        private int id_movimiento;
        private string cod_producto;     
        private int cantidad;
        private int valor;

        //Vacio 
        public clsDetCompra()
        {
        }        


        //Lleno
        public clsDetCompra(int id_movimiento, string CodProd, int cant, int val)
        {
            this.id_movimiento = id_movimiento;
            this.Cod_producto = CodProd;
            this.Cantidad = cant;
            this.Valor = val;
        }
        #region

        public int Id_movimiento
        {
            get { return id_movimiento; }
            set { id_movimiento = value; }
        }


        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public string Cod_producto
        {
            get { return cod_producto; }
            set { cod_producto = value; }
        }

        #endregion

    }

    
}
