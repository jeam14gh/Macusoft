using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    class clsClientes
    {
        public bool RegistrarPersona(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            Datos.clsAdministrador Admin = new Datos.clsAdministrador();
            return Admin.RegistrarPersona(oclsAdministrador, vend, oclsCliente);
        }
        public DataTable Consultar_Persona(string nmbre, string apellido, string documento)
        {
            Datos.clsAdministrador admin = new Datos.clsAdministrador();
            return admin.Consultar_Persona(nmbre, apellido, documento);
        }
        public bool Actualizar_usuario(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            Datos.clsAdministrador admin = new Datos.clsAdministrador();
            return admin.Actualizar_Persona(oclsAdministrador, vend, oclsCliente);
        }
    }
}
