using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsDian
    {
        Comun.clsDian dia = new Comun.clsDian();
        Datos.clsDian Ddia = new Datos.clsDian();
        public bool Registrar_dian(int ini, int fin)
        {
            dia.Rango_Inicial = ini;
            dia.Rango_Final = fin;
            return Ddia.Registrar_Dian(dia);
        }
        public bool Actualizar_Dian()
        {
            return Ddia.Actualizar_Dian();
        }

        public DataTable Consultar_Dian()
        {
            return Ddia.Consultar_Dian();
        }
        public DataTable Consultar_Ventas(int dian)
        {
            return Ddia.Consultar_Ventas(dian);
        }
    }
}
