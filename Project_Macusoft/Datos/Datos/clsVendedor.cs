using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class  clsVendedor:clsPersona
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
                SqlCommand cmIntVendedor = new SqlCommand(SP_Registrar_Usuarios, con);
                cmIntVendedor.CommandType = CommandType.StoredProcedure;
                cmIntVendedor.Parameters.AddWithValue("@Fecha", vend.Fecha_registro);
                cmIntVendedor.Parameters.AddWithValue("@Nombre", vend.Nombre);
                cmIntVendedor.Parameters.AddWithValue("@Apellido", vend.Apellidos);
                cmIntVendedor.Parameters.AddWithValue("@Tipo_ducmento", vend.Tipo_documento);
                cmIntVendedor.Parameters.AddWithValue("@Documento", vend.N_documento);
                cmIntVendedor.Parameters.AddWithValue("@Direccion", vend.Direccion);
                cmIntVendedor.Parameters.AddWithValue("@Telefono", vend.Telefono);
                cmIntVendedor.Parameters.AddWithValue("@Correo", vend.Email);
                cmIntVendedor.Parameters.AddWithValue("@Nacimiento", vend.Fecha_nacimiento);

                int intResultado = cmIntVendedor.ExecuteNonQuery();
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
                SqlDataAdapter datVendedor = new SqlDataAdapter(SP_Consultar_Usuarios, cn);
                // Especificamos el tipo de conexión.
                datVendedor.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Asignamos los valores a los parametros del SP:
                datVendedor.SelectCommand.Parameters.AddWithValue("@Nombre", nom);
                datVendedor.SelectCommand.Parameters.AddWithValue("@Apellido", ape);
                datVendedor.SelectCommand.Parameters.AddWithValue("@Documento", doc);

                DataTable dtContVendedor = new DataTable();
                datVendedor.Fill(dtContVendedor);

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
                SqlCommand cmIntvendedor = new SqlCommand(SP_Actualizar_Usuarios, con);
                cmIntvendedor.CommandType = CommandType.StoredProcedure;
                cmIntvendedor.Parameters.AddWithValue("@Fecha", vend.Fecha_registro);
                cmIntvendedor.Parameters.AddWithValue("@Nombre", vend.Nombre);
                cmIntvendedor.Parameters.AddWithValue("@Apellido", vend.Apellidos);
                cmIntvendedor.Parameters.AddWithValue("@Documento", vend.N_documento);
                cmIntvendedor.Parameters.AddWithValue("@Direccion", vend.Direccion);
                cmIntvendedor.Parameters.AddWithValue("@Telefono", vend.Telefono);
                cmIntvendedor.Parameters.AddWithValue("@Correo", vend.Email);


                int intResultado = cmIntvendedor.ExecuteNonQuery();
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
