using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logica
{
    public class clsDevolucionCliente
    {
        Comun.clsDevolucionCliente CoDevClie = new Comun.clsDevolucionCliente();
        Datos.clsDevolucionCliente DaDevClie = new Datos.clsDevolucionCliente();
        public bool Registrar_Devolucion(string documento_cliente, string motivos, int novedad, int tipo)
        {
            CoDevClie.Documento_cliente = documento_cliente;
            CoDevClie.Motivos = motivos;
            CoDevClie.Novedad = novedad;
            CoDevClie.Tipo = tipo;
           return DaDevClie.RegistrarDevClien(CoDevClie);
        }
    }
}
