using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsProveedores : clsPersona
    {
        public clsProveedores() { }

        public clsProveedores(string nombre_razonSocial, string direccion, string telefono, string nit_documento, string email, byte idDepto, int idMun)
        {
            this.Nombre = nombre_razonSocial;
            this.N_documento = nit_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;

            //Instanciamos la clsMunicipio y le pasamos lleno el idMun y se lo asignamos al atributo de esta clase (this.Municipio)
            clsDepartamento oDepto = new clsDepartamento();
            oDepto.Id_departamento = idDepto;
            this.Departamento = oDepto;

            clsMunicipio oMun = new clsMunicipio();
            oMun.Id_municipio = idMun;
            this.Municipio = oMun;
        }

    }
}
