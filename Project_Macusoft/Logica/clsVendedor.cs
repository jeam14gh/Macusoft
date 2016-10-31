using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logica
{
    public class clsVendedor
    {
        Comun.clsVendedor oVendedor = new Comun.clsVendedor();
        Datos.clsVendedor D_oVendedor = new Datos.clsVendedor();
        Comun.clsMunicipio oMunicipio = new Comun.clsMunicipio();
        Comun.clsSucursal oSucursal = new Comun.clsSucursal();

        public bool Registrar_Vendedor(string nombre, string apellido, string direccion, string telefono, string n_documento,
                                            DateTime fecha_nacimiento, string email, int id_municipio, int id_sucursal)
        {
            oMunicipio.Id_municipio = id_municipio;
            oSucursal.Id_sucursal = id_sucursal;
            oVendedor = new Comun.clsVendedor(nombre, apellido, direccion, telefono, n_documento, fecha_nacimiento, email, oMunicipio,oSucursal);
            return D_oVendedor.Registrar_Vendedor(oVendedor);
        }

        public bool Actualizar_Vendedor(string nombre, string apellido, string direccion, string telefono, string n_documento,
                                           DateTime fecha_nacimiento, string email, int id_municipio, int id_sucursal)
        {
            oMunicipio.Id_municipio = id_municipio;
            oSucursal.Id_sucursal = id_sucursal;
            oVendedor = new Comun.clsVendedor(nombre, apellido, direccion, telefono, n_documento, fecha_nacimiento, email, oMunicipio, oSucursal);
            return D_oVendedor.Actualizar_Vendedor(oVendedor);
        }

        public bool Actualizar_Vendedores(Comun.clsVendedor persona)
                                  
        {
         return D_oVendedor.Actualizar_Vendedor(persona);
        }


        public DataTable Olvido_Contrasenia(string email,string documento)
        {
            
            return D_oVendedor.Olvido_Contrasenia(email,documento);
        }

        public DataTable Consultar(string strDocEmpleado)
        {
            Datos.clsVendedor oDclsVendedor = new Datos.clsVendedor();
            return oDclsVendedor.Consultar(strDocEmpleado);
        }
    }
}
