using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsAdministrador
    {
        Comun.clsAdministrador oAdministrador = new Comun.clsAdministrador();
        Datos.clsAdministrador D_oAdministrador = new Datos.clsAdministrador();
        Comun.clsMunicipio oMunicipio = new Comun.clsMunicipio();

        public bool Registrar_Administrador(string nombre, string apellido, string direccion, string telefono, string n_documento,
                                            DateTime fecha_nacimiento, string email, int id_municipio)
        {
            oMunicipio.Id_municipio = id_municipio;
            oAdministrador = new Comun.clsAdministrador(nombre, apellido, direccion, telefono, n_documento, fecha_nacimiento, email, oMunicipio);

            return D_oAdministrador.Registrar_Administrador(oAdministrador);
        }

        public bool Actualizar_Administrador(string nombre, string apellido, string direccion, string telefono, string n_documento,
                                           DateTime fecha_nacimiento, string email, int id_municipio)
        {
            oMunicipio.Id_municipio = id_municipio;
            oAdministrador = new Comun.clsAdministrador(nombre, apellido, direccion, telefono, n_documento, fecha_nacimiento, email, oMunicipio);

            return D_oAdministrador.Actualizar_Administrador(oAdministrador);
        }

     
        public DataTable dt_ListarUsuarios()
        {
            return D_oAdministrador.listarUsuarios();
        }

        public bool Olvido_Contrasenia()
        {

            return D_oAdministrador.Olvido_Contrasenia(oAdministrador);
        }
    }
}
