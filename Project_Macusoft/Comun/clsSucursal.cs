using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsSucursal
    {
        //ATRIBUTOS
        private string direccion_sucursal;
        private int id_sucursal;
        private string nombre_sucursal;
        private string telefono_sucursal;

        //SET Y GET
        public string Telefono_sucursal
        {
            get { return telefono_sucursal; }
            set { telefono_sucursal = value; }
        }

        public string Nombre_sucursal
        {
            get { return nombre_sucursal; }
            set { nombre_sucursal = value; }
        }

        public int Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }


        public string Direccion_sucursal
        {
            get { return direccion_sucursal; }
            set { direccion_sucursal = value; }
        }

        //CONSTRUCTOR VACIO
        public clsSucursal()
        {

        }

        //CONSTRUCTOR CON ARGUMENTOS
        public clsSucursal(string direccion_sucursal, int id_sucursal, string nombre_sucursal, string telefono_sucursal)
        {

            this.direccion_sucursal = direccion_sucursal;
            this.Id_sucursal = id_sucursal;
            this.Nombre_sucursal = nombre_sucursal;
            this.Telefono_sucursal = telefono_sucursal;

        }
    }
}
