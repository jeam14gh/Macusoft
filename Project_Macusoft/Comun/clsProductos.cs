using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsProductos
    {
        #region ATRIBUTOS
        private string referencia;
        private clsCategorias oCatgorias;   
        private string nombre_producto;
        private int existencias_actuales;
        private int stock_minimo;
        private int stock_maximo;
        private string imagen;
        private int costo_compra;
        private int costo_venta;
        private int mayor;

       
        #endregion

        #region METODOS GET y SET
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        public clsCategorias OCatgorias
        {
            get { return oCatgorias; }
            set { oCatgorias = value; }
        }

        public string Nombre_producto
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }

        public int Existencias_actuales
        {
            get { return existencias_actuales; }
            set { existencias_actuales = value; }
        }

        public int Stock_minimo
        {
            get { return stock_minimo; }
            set { stock_minimo = value; }
        }

        public int Stock_maximo
        {
            get { return stock_maximo; }
            set { stock_maximo = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public int Costo_compra
        {
            get { return costo_compra; }
            set { costo_compra = value; }
        }


        public int Costo_venta
        {
            get { return costo_venta; }
            set { costo_venta = value; }
        }
        public int Mayor
        {
            get { return mayor; }
            set { mayor = value; }
        }
        #endregion

        public clsProductos() { }

        public clsProductos(string codPro, int idCat, string nom_pro, int exi_act, int sto_min, int sto_max, int cos_com, int cos_ven,int may)
        {
            this.Referencia = codPro;

            clsCategorias oCat = new clsCategorias();
            oCat.Id_categoria = idCat;
            this.OCatgorias = oCat;

            this.Nombre_producto = nom_pro;
            this.Existencias_actuales = exi_act;
            this.Stock_minimo = sto_min;
            this.Stock_maximo = sto_max;
            this.Costo_compra = cos_com;
            this.Costo_venta = cos_ven;
            this.Mayor = may;
        }
    }
}

