using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsVendedor : clsPersona
    {
        private clsSucursal sucursal;

        public clsSucursal Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        public clsVendedor()
        { }

        //CONSTRUCTOR HEREDADO DE LA Comun.clsPersona
        public clsVendedor(string nombre, string apellidos, string direccion, string telefono, string n_documento,
        DateTime fecha_nacimiento, string email, clsMunicipio municipio, clsSucursal sucursal)
           
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.N_documento = n_documento;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Email = email;
            this.Municipio = municipio;
            this.Sucursal = sucursal;
        }
    }

}
