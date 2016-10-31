using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    class clsVendedor
    {
        public bool RegistrarPersona(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            Datos.clsVendedor Vend = new Datos.clsVendedor();
            return Vend.RegistrarPersona(oclsAdministrador, vend, oclsCliente);
        }
        public DataTable Consultar_Persona(string nmbre, string apellido, string documento)
        {
            Datos.clsVendedor Vend = new Datos.clsVendedor();
            return Vend.Consultar_Persona(nmbre, apellido, documento);
        }
        public bool Actualizar_usuario(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            Datos.clsVendedor Vend = new Datos.clsVendedor();
            return Vend.Actualizar_Persona(oclsAdministrador, vend, oclsCliente);
        }
    }
}
