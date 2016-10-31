using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;

namespace Logica
{
    public class clsProveedores
    {
        Comun.clsProveedores CoProv = new Comun.clsProveedores();
        Datos.clsProveedores DoProv = new Datos.clsProveedores();

        public bool registrarProveedor(string nombre_razonSocial, string direccion, string telefono, string nit_documento, string email, byte idDep, int idMun)
        {
            CoProv = new Comun.clsProveedores(nombre_razonSocial, direccion, telefono, nit_documento, email, idDep, idMun);
            return DoProv.registrarProveedor(CoProv);
        }

        public bool EliminarProveedor(string nit_documento)
        {
            CoProv.N_documento = nit_documento;
            return DoProv.EliminarProveedor(CoProv);
        }


        public bool actualizarProveedor(string nombre_razonSocial, string direccion, string telefono, string nit_documento, string email, byte idDep, int idMun)
        {
            CoProv = new Comun.clsProveedores(nombre_razonSocial, direccion, telefono, nit_documento, email, idDep, idMun);
            return DoProv.ActualizarProveedor(CoProv);
        }

        public DataTable dt_ConsulatarProveedores(string nombre_razonSocial, string nit_documento)
        {
            CoProv.Nombre = nombre_razonSocial;
            CoProv.N_documento = nit_documento;
            return DoProv.consultarProveedor(CoProv);
        }

        public DataTable dt_ListarProveedores()
        {
            return DoProv.listarProveedor();
        }
        
    }
}
