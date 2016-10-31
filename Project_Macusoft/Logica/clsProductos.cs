using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class clsProductos
    {
        Comun.clsProductos CoPro = new Comun.clsProductos();
        Datos.clsProductos DoPro = new Datos.clsProductos();
        Comun.clsCategorias CoCat = new Comun.clsCategorias();

        public bool RegistrarProducto(string codPro, int idCat, string nom_pro, int exi_act, int sto_min, int sto_max, int cos_com, int cos_ven,int may)
        {
            CoPro = new Comun.clsProductos(codPro, idCat, nom_pro, exi_act, sto_min, sto_max, cos_com, cos_ven,may);
            return DoPro.RegistrarProducto(CoPro);
        }

        public bool ActualizarProducto(string codPro, int idCat, string nom_pro, int exi_act, int sto_min, int sto_max,  int cos_com, int cos_ven,int may)
        {
            CoPro = new Comun.clsProductos(codPro, idCat, nom_pro, exi_act, sto_min, sto_max,  cos_com, cos_ven,may);
            return DoPro.ActualizarProducto(CoPro);
        }

        public DataTable dtConsultarProducto(string codPro, string nom_pro, int idCat)
        {
            CoPro.Referencia = codPro;

            CoCat = new Comun.clsCategorias();
            CoCat.Id_categoria = idCat;
            CoPro.OCatgorias = CoCat;

            CoPro.Nombre_producto = nom_pro;
            return DoPro.ConsultarProducto(CoPro);
        }

        public DataTable dt_ListarProductos()
        {
            return DoPro.listarProductos();
        }

        //Metodo para cargar los productos mediante su categoria
      
        public bool Disminuir(string cod)
        {
            CoPro.Referencia = cod;
            return DoPro.PromedioPondedaroSalidas(CoPro);
        }

        public DataTable ProductoCod(string cod)
        {
            return DoPro.ConsultarProductoCod(cod);
        }
       
        public bool Aumentar_Existencias(string cod)
        {
            CoPro.Referencia = cod;
            return DoPro.PromedioPondedaroEntradas(CoPro);
        }
       
        public DataTable dtListarProductosXCategorias(int idCategoria)
        {
            return new Datos.clsProductos().ListarProductosXCategoria(idCategoria);
        }

        public DataTable CostoVenta(string cod)
        {
            Datos.clsProductos Pd=new Datos.clsProductos();
            return Pd.CostoVenta(cod);
        }
        public bool ActualizarExistencias(string cod)
        {
            return new Datos.clsProductos().ActualizarExistencias(cod);
        }
    }
}
