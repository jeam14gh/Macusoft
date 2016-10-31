using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class clsVentas
    {
        Comun.clsVentas CoVen;
        Datos.clsVentas DoVen=new Datos.clsVentas();

        public List<string> autocompletarNombre(string nombreRazSoc)
        {
            return new Datos.clsVentas().GetNombre_RazonSocial(nombreRazSoc);
        }

        public DataTable dt_RegistrarVenta(string docNit_cli, string docEmp, int des, int dian)
        {
            CoVen=new Comun.clsVentas(docNit_cli, docEmp, des, dian);
            return DoVen.dt_RegistrarVenta(CoVen);
        }
    }
}
