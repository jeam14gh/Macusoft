using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsVentas
    {       
        private string docNit_cliente;        
        private string docEmpleado;
        private int descuento;
        private int dian;              
        
        #region GET y SET
              
        public string DocNit_cliente
        {
            get { return docNit_cliente; }
            set { docNit_cliente = value; }
        }

        public string DocEmpleado
        {
            get { return docEmpleado; }
            set { docEmpleado = value; }
        }  
              
        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }       

        public int Dian
        {
            get { return dian; }
            set { dian = value; }
        }
               
        #endregion

        public clsVentas() { }

        public clsVentas(string docNit_cli,string docEmp,int des,int dian)
        {
            this.DocNit_cliente = docNit_cli;
            this.DocEmpleado = docEmp;
            this.Descuento = des;
            this.Dian = dian;
        }
    }
}
