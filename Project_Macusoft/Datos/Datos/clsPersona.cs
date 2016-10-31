using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Datos
{
    public abstract class clsPersona
    {
        public abstract bool RegistrarPersona(Comun.clsAdministrador oclsAdministrador,Comun.clsVendedor vend ,Comun.clsClientes oclsCliente);
        public abstract DataTable Consultar_Persona(string nom,string ape,string doc);
        public abstract bool Actualizar_Persona(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente);
    }
}
