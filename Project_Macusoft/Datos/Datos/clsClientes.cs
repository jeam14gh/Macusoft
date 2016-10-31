using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    class clsClientes:clsPersona
    {
        public override bool RegistrarPersona(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_Registrar_Usuarios = "dbo.SP_Registrar_Usuarios";
                SqlCommand cmIntCliente = new SqlCommand(SP_Registrar_Usuarios, con);
                cmIntCliente.CommandType = CommandType.StoredProcedure;
                cmIntCliente.Parameters.AddWithValue("@Fecha", oclsCliente.Fecha_registro);
                cmIntCliente.Parameters.AddWithValue("@Nombre", oclsCliente.Nombre);
                cmIntCliente.Parameters.AddWithValue("@Apellido", oclsCliente.Apellidos);
                cmIntCliente.Parameters.AddWithValue("@Tipo_ducmento", oclsCliente.Tipo_documento);
                cmIntCliente.Parameters.AddWithValue("@Documento", oclsCliente.N_documento);
                cmIntCliente.Parameters.AddWithValue("@Direccion", oclsCliente.Direccion);
                cmIntCliente.Parameters.AddWithValue("@Telefono", oclsCliente.Telefono);
                cmIntCliente.Parameters.AddWithValue("@Correo", oclsCliente.Email);
                cmIntCliente.Parameters.AddWithValue("@Nacimiento", oclsCliente.Fecha_nacimiento);

                int intResultado = cmIntCliente.ExecuteNonQuery();
                if (intResultado > 0)
                { Registro = true; }
            }
            catch (Exception e)
            { Registro = false; }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return Registro;

        }

        public override DataTable Consultar_Persona(string nom, string ape, string doc)
        {
            //var Resultado = new List<Comun.ClsAdministrador>();

            SqlConnection cn = new SqlConnection();

            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();

                // Especificamos el nombre del procedimiento almacenado.
                string SP_Consultar_Usuarios = "dbo.SP_Consultar_Usuarios";
                // Esteblezco el Tipo de Conección para el SqlDataAdapter "datContAdministrador"
                SqlDataAdapter datCliente = new SqlDataAdapter(SP_Consultar_Usuarios, cn);
                // Especificamos el tipo de conexión.
                datCliente.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Asignamos los valores a los parametros del SP:
                datCliente.SelectCommand.Parameters.AddWithValue("@Nombre", nom);
                datCliente.SelectCommand.Parameters.AddWithValue("@Apellido", ape);
                datCliente.SelectCommand.Parameters.AddWithValue("@Documento", doc);

                DataTable dtContVendedor = new DataTable();
                datCliente.Fill(dtContVendedor);

                return dtContVendedor;
            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                cn.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                cn.Dispose();
            }

            return null;
        }

        public override bool Actualizar_Persona(Comun.clsAdministrador oclsAdministrador, Comun.clsVendedor vend, Comun.clsClientes oclsCliente)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_Actualizar_Usuarios = "dbo.SP_Actualizar_Usuarios";
                SqlCommand cmInCliente = new SqlCommand(SP_Actualizar_Usuarios, con);
                cmInCliente.CommandType = CommandType.StoredProcedure;
                cmInCliente.Parameters.AddWithValue("@Fecha", oclsCliente.Fecha_registro);
                cmInCliente.Parameters.AddWithValue("@Nombre", oclsCliente.Nombre);
                cmInCliente.Parameters.AddWithValue("@Apellido", oclsCliente.Apellidos);
                cmInCliente.Parameters.AddWithValue("@Documento", oclsCliente.N_documento);
                cmInCliente.Parameters.AddWithValue("@Direccion", oclsCliente.Direccion);
                cmInCliente.Parameters.AddWithValue("@Telefono", oclsCliente.Telefono);
                cmInCliente.Parameters.AddWithValue("@Correo", oclsCliente.Email);


                int intResultado = cmInCliente.ExecuteNonQuery();
                if (intResultado > 0)
                { Registro = true; }
            }
            catch (Exception e)
            { Registro = false; }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return Registro;

        }
    }
}
