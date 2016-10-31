using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;

namespace Logica
{
    public class clsCuenta
    {
        Comun.clsCuenta oCuenta = new Comun.clsCuenta();
        Datos.clsCuenta D_oCuenta = new Datos.clsCuenta();
        Comun.clsMunicipio oMunicipio = new Comun.clsMunicipio();
        Comun.clsAdministrador oAdministrador=new Comun.clsAdministrador();
        Comun.clsVendedor oVendedor = new Comun.clsVendedor();

        public string Generar_Clave_SHA1(string strContrasenia)
        {
            // Especificamos el Tipo de Encriptación (representa cada punto de código como una secuencia de uno a cuatro bytes.).
            UTF8Encoding enc = new UTF8Encoding();
            // Especificamos el Vector "data", que tendra la cadena a convertir, y el vector
            // resultado, que tendra la cadena convertida.
            byte[] data = enc.GetBytes(strContrasenia);
            byte[] resultado;

            // El código siguiente calcula el valor de sha a SHA1 para el Vector "data" y se almacena en Vector "result".
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            // Esta es una implementación de la Clase Abstracta SHA1.
            resultado = sha.ComputeHash(data);

            // Convertir los valores en hexadecimal
            // cuando tiene una cifra hay que rellenarlo con cero
            // para que siempre ocupen dos dígitos.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultado.Length; i++)
            {
                if (resultado[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(resultado[i].ToString("x"));
            }
            // Retornamos la Cadena Convertida a Mayusculas.
            return sb.ToString().ToUpper();
        }

        public bool RegistrarCuenta(string cargo, string contrasenia, string estado_cuenta, string nombre_usuario, string docu_administrador,string docu_vendedor)
        {

            oAdministrador.N_documento = docu_administrador;
            oCuenta = new Comun.clsCuenta(cargo, contrasenia, estado_cuenta, nombre_usuario, oAdministrador,oVendedor);
            return D_oCuenta.RegistrarCuenta(oCuenta);
        }

        public bool Actualizar_Cuenta(string cargo, string estado_cuenta,  string docu_administrador, string docu_vendedor)
        {

            oAdministrador.N_documento = docu_administrador;
            oCuenta = new Comun.clsCuenta(cargo, "", estado_cuenta, "", oAdministrador, oVendedor);
            return D_oCuenta.Actualizar_Cuenta(oCuenta);
        }
        
        public DataTable Iniciar_Sesion(string Login, string Conrasenia)
         {
            Datos.clsCuenta oclsCuenta = new Datos.clsCuenta();
            return oclsCuenta.Iniciar_Session(Login, Conrasenia);
        }

        public bool ModificarContrasenia(string doc, string cont)
        {
            Datos.clsCuenta oclsCuenta = new Datos.clsCuenta();
            return oclsCuenta.ModificarContrasenia(doc, cont);
        }
        public bool ActualizarContrasenia(string doc, string cont)
        {
            Datos.clsCuenta oclsCuenta = new Datos.clsCuenta();
            return oclsCuenta.ActualizarContrasenia(doc, cont);
        }
    }
}
