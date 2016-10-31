using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class clsComidas
    {
        /// <summary>
        /// Registra la comida y su detalle
        /// </summary>
        /// <param name="oCom"></param>
        /// <returns></returns>
        public void RegistrarComida(Comun.clsComidas oCom)
        {
            var comida=new Comun.clsComidas(oCom.Comida,oCom.Precio);
            var idComida = Datos.clsComidas.RegistrarComida(comida);
            
            for (int i = 0; i < oCom.Productos.Count; i++)
            {
                new Datos.clsComidas().RegistrarDetalleComidaXProd(oCom.Productos[i].Cod_Product, oCom.Productos[i].Cantidad, idComida);
            }

        }

    }
}
