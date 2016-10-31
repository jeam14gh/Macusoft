using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comun;
//AUTOR: Jhon Alvarez


namespace Logica
{
    public class clsClientes
    {
        Comun.clsClientes CoCli = new Comun.clsClientes();
        Datos.clsClientes DoCli = new Datos.clsClientes();

        public bool Registrar_Cliente(string nombre_razonSocial, string direccion, string telefono, string nit_documento, string email, byte idDep, int idMun, DateTime fecha_cumple)
        {
            CoCli = new Comun.clsClientes(nombre_razonSocial, direccion, telefono, nit_documento, email, idDep, idMun, fecha_cumple);
            return DoCli.Registrar_Cliente(CoCli);
        }

        public bool ActualizarCliente_Logica(string nombre_razonSocial, string direccion, string telefono, string nit_documento, string email, byte idDep, int idMun, DateTime fecha_cumple)
        {
            CoCli = new Comun.clsClientes(nombre_razonSocial, direccion, telefono, nit_documento, email, idDep, idMun, fecha_cumple);
            return DoCli.Actualizar_Cliente(CoCli);
        }

        public bool EliminarCliente(string nit_documento)
        {
            CoCli.N_documento = nit_documento;
            return DoCli.EliminarCliente(CoCli);
        }

        public DataTable dt_ConsultarCliente(string nombre_razonSocial, string nit_documento)
        {
            CoCli.Nombre = nombre_razonSocial;
            CoCli.N_documento = nit_documento;
            return DoCli.consultar(CoCli);
        }

        public DataTable dt_ListarCliente()
        {
            return DoCli.listarClientes();
        }            
    }
}



