using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsCompras
    {
        //Llamamos la clase comun, y la de datos.
        Comun.clsCompras CoCompras = new Comun.clsCompras();
        Datos.clsCompras DoCOmpras = new Datos.clsCompras();

        //Parametros que recibe de la capa de datos y comun.
        public DataTable Registrar_Compras(string doc_nit,string forma_pag,int id_tip_mov)
        {
            CoCompras.Documento_nit = doc_nit;
            CoCompras.Forma_pago=forma_pag;
            CoCompras.Id_tipo_movimiento = id_tip_mov;

            return DoCOmpras.RegistrarCompras(CoCompras);
        }

        public DataTable ListarCompras()
        {

            return DoCOmpras.Consultarcompras();
        }

        public DataTable ConsultarCompras(string Provee)
        {
            CoCompras.Documento_nit = Provee;

            return DoCOmpras.ConsultarComprasProv(CoCompras);

        }

    }
}
