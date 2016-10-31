using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsCuenta
    {
      //ATRIBUTOS
        private string nombre_usuario;
        private string contrasenia;
        private string cargo;
        private string estado_cuenta;
        private clsAdministrador oclsAdministrador;
        private clsVendedor oclsVendedor;

        public clsAdministrador OclsAdministrador
        {
            get { return oclsAdministrador; }
            set { oclsAdministrador = value; }
        }

        public clsVendedor OclsVendedor
        {
            get { return oclsVendedor; }
            set { oclsVendedor = value; }
        }

        public string Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        public string Estado_cuenta
        {
            get { return estado_cuenta; }
            set { estado_cuenta = value; }
        }

        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        //CONSTRUCTOR VACIO

        public clsCuenta() { 
        
        }

        //Jhon: agregue los parametros clsVendedor y clsAdministrador en el constructor
        //CONSTRUCTOR CON ARGUMENTOS
        public clsCuenta(string cargo, string contrasenia, string estado_cuenta, string nombre_usuario, clsAdministrador objclsAdministrador, clsVendedor objclsVendedor)
        {
            this.Cargo = cargo;
            this.Contrasenia = contrasenia;
            this.Estado_cuenta = estado_cuenta;
            this.Nombre_usuario = nombre_usuario;
            this.OclsAdministrador = objclsAdministrador;
            this.OclsVendedor = objclsVendedor;
            
        }
    
    }
}
