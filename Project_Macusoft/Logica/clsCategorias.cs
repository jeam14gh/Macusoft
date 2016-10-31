using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsCategorias
    {
        //Llamamos la clase comun, y la de datos.
        Comun.clsCategorias oCategoria = new Comun.clsCategorias();
        Datos.clsCategorias oDCategoria = new Datos.clsCategorias();

        //Parametros que recibe de la capa de datos y comun.
        public bool Registrar_Categoria(string strNombre_categoria)
        {
            oCategoria.nomb_catego = strNombre_categoria;
            return oDCategoria.Registrar_categoria(oCategoria);
        }


        public DataTable Listar_Categorias()
        {
            Datos.clsCategorias oclCategoria = new Datos.clsCategorias();
            return oclCategoria.ListarCategoria();
        }

        public DataTable Consultar_Categorias(string nombre)
        {
            oCategoria.nomb_catego = nombre;

            return oDCategoria.ConsultarCategoria(oCategoria);

        }

        public bool ActualizarCategorias(int id, string nombre)
        {
            oCategoria.Id_categoria = id;
            oCategoria.nomb_catego = nombre;

            return oDCategoria.Actualizar_Categoria(oCategoria);
        }

        public DataTable Consultar_Categoria(int cod)
        {
            return oDCategoria.ConsultarCategoria(cod);
        }
       
        public DataTable dtListarCategorias()
        {
            return new Datos.clsCategorias().ListarCategoria();
        }
    }
}
