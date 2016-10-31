using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsComidas
    {
        public int IdComida { get; set; }
        /// <summary>
        /// Nombre de la comida
        /// </summary>
        public string Comida { get; set; }
        /// <summary>
        /// Precio de la comida
        /// </summary>
        public int Precio { get; set; }

        /// <summary>
        /// Lista de productos de una comida
        /// </summary>
        public List<Comun.clsDetalles> Productos { get; set; }
        
        
        // Constructor vacio
        public clsComidas() {   }

        public clsComidas(string comida,int precio)
        {
            this.Comida = comida;
            this.Precio = precio;
        }

        public clsComidas(int idComida, List<Comun.clsDetalles> productos)
        {
            this.IdComida = idComida;
            this.Productos = productos;
        }
    }
    
}
