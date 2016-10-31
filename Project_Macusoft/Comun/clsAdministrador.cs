using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsAdministrador : clsPersona
    {

        //private clsSucursal sucursal;

        //public clsSucursal Sucursal
        //{
        //    get { return sucursal; }
        //    set { sucursal = value; }
        //}
        
        public clsAdministrador()
        { 
        }

        //CONSTRUCTOR HEREDADO DE LA Comun.clsPersona
        public clsAdministrador(string nombre, string apellido, string direccion, string telefono, string n_documento,
                                DateTime fecha_nacimiento, string email,clsMunicipio municipio)
           
        {
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.N_documento = n_documento;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Email = email;
            //this.Sucursal = sucursal;
            this.Municipio = municipio;
           
           
        }
    }
  }
