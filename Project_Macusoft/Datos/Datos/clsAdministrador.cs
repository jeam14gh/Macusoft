using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Datos
{
    public class clsAdministrador:clsPersona
    {
      public  override bool RegistrarPersona(Comun.clsAdministrador oclsAdministrador,Comun.clsVendedor vend ,Comun.clsClientes oclsCliente)
        {
            bool Registro = false;
            SqlConnection con =new SqlConnection();
            try
            {
               Conexion oClsConexion = new Conexion();
               con = oClsConexion.slConexion();
               con.Open();
               string SP_Registrar_Usuarios = "dbo.SP_Registrar_Usuarios";
               SqlCommand cmIntAdministrador = new SqlCommand(SP_Registrar_Usuarios, con);
               cmIntAdministrador.CommandType = CommandType.StoredProcedure;
               cmIntAdministrador.Parameters.AddWithValue("@Fecha", oclsAdministrador.Fecha_registro);
               cmIntAdministrador.Parameters.AddWithValue("@Nombre", oclsAdministrador.Nombre);
               cmIntAdministrador.Parameters.AddWithValue("@Apellido", oclsAdministrador.Apellidos);
               cmIntAdministrador.Parameters.AddWithValue("@Tipo_ducmento", oclsAdministrador.Tipo_documento);
               cmIntAdministrador.Parameters.AddWithValue("@Documento", oclsAdministrador.N_documento);
               cmIntAdministrador.Parameters.AddWithValue("@Direccion", oclsAdministrador.Direccion);
               cmIntAdministrador.Parameters.AddWithValue("@Telefono", oclsAdministrador.Telefono);
               cmIntAdministrador.Parameters.AddWithValue("@Correo", oclsAdministrador.Email);
               cmIntAdministrador.Parameters.AddWithValue("@Nacimiento", oclsAdministrador.Fecha_nacimiento);

                  int intResultado = cmIntAdministrador.ExecuteNonQuery();
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
                SqlDataAdapter datContAdministrador = new SqlDataAdapter(SP_Consultar_Usuarios, cn);
                // Especificamos el tipo de conexión.
                datContAdministrador.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Asignamos los valores a los parametros del SP:
                datContAdministrador.SelectCommand.Parameters.AddWithValue("@Nombre", nom);
                datContAdministrador.SelectCommand.Parameters.AddWithValue("@Apellido", ape);
                datContAdministrador.SelectCommand.Parameters.AddWithValue("@Documento", doc);

                DataTable dtContAdministrador = new DataTable();
                datContAdministrador.Fill(dtContAdministrador);

                return dtContAdministrador;
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
            SqlConnection con =new SqlConnection();
            try
            {
               Conexion oClsConexion = new Conexion();
               con = oClsConexion.slConexion();
               con.Open();
               string SP_Actualizar_Usuarios = "dbo.SP_Actualizar_Usuarios";
               SqlCommand cmIntAdministrador = new SqlCommand(SP_Actualizar_Usuarios, con);
               cmIntAdministrador.CommandType = CommandType.StoredProcedure;
               cmIntAdministrador.Parameters.AddWithValue("@Fecha", oclsAdministrador.Fecha_registro);
               cmIntAdministrador.Parameters.AddWithValue("@Nombre", oclsAdministrador.Nombre);
               cmIntAdministrador.Parameters.AddWithValue("@Apellido", oclsAdministrador.Apellidos);
               cmIntAdministrador.Parameters.AddWithValue("@Documento", oclsAdministrador.N_documento);
               cmIntAdministrador.Parameters.AddWithValue("@Direccion", oclsAdministrador.Direccion);
               cmIntAdministrador.Parameters.AddWithValue("@Telefono", oclsAdministrador.Telefono);
               cmIntAdministrador.Parameters.AddWithValue("@Correo", oclsAdministrador.Email);


                  int intResultado = cmIntAdministrador.ExecuteNonQuery();
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

    

