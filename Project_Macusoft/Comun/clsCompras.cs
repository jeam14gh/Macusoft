using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsCompras
    {
        //Atributos
       
        private string documento_nit;
        private string forma_pago;
        private int id_tipo_movimiento;

     
    

        //Vacion
        public clsCompras()
        {
        }

        //lleno
        public clsCompras(string doc,string form_pag,int idtipmov)
        {

            this.Documento_nit = doc;
            this.Forma_pago = form_pag;
            this.Id_tipo_movimiento = idtipmov;
         
        }
     


        #region Metodos set y get


       
        public string Documento_nit
        {
            get { return documento_nit; }
            set { documento_nit = value; }
        }

        public string Forma_pago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
        }

        public int Id_tipo_movimiento
        {
            get { return id_tipo_movimiento; }
            set { id_tipo_movimiento = value; }
        }

       
        #endregion 

    }
}
