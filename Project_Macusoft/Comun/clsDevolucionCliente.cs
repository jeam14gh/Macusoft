using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{

    //Atributos de devuciones a clientes
    public class clsDevolucionCliente
    {
        #region Atributos
        private string documento_cliente;
        private string documento_empleado;
        private string motivos;
        private int novedad;
        private int tipo;
        #endregion
        #region Metodos Set y Get

        public string Documento_cliente
        {
            get { return documento_cliente; }
            set { documento_cliente = value; }
        }
        

        public string Documento_empleado
        {
            get { return documento_empleado; }
            set { documento_empleado = value; }
        }
        

        public string Motivos
        {
            get { return motivos; }
            set { motivos = value; }
        }
        

        public int Novedad
        {
            get { return novedad; }
            set { novedad = value; }
        }
        

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        #endregion

        #region Constructores
        public clsDevolucionCliente()
        {
        }
        public clsDevolucionCliente(string documento_cliente,string documento_empleado,string motivos,int novedad,int tipo)
        {
            this.Documento_cliente = documento_cliente;
            this.Documento_empleado = documento_empleado;
            this.Motivos = motivos;
            this.Novedad = novedad;
            this.Tipo = tipo;
        }
        #endregion
    }
}