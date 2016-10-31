using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsCategorias
    {
         private int id_categoria;

        private string Nombre_categoria;

        //Vacio
        public clsCategorias()
        {

        }


        //Parametros
        public clsCategorias(int id_categoria, string nomb_catego)
        {
            this.id_categoria = Id_categoria;
            this.Nombre_categoria = nomb_catego;


        }


        #region Metodos set y get
        public string nomb_catego
        {
            set { Nombre_categoria = value; }
            get { return Nombre_categoria; }

        }

        public int Id_categoria
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        #endregion
    }

}
