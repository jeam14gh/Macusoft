using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
   public class clsDian
    {
        #region Atributos
        int rango_Inicial;
        int rango_Final;
        #endregion
        #region Metodos Set y Get
        public int Rango_Inicial
        {
            get { return rango_Inicial; }
            set { rango_Inicial = value; }
        }
        public int Rango_Final
        {
            get { return rango_Final; }
            set { rango_Final = value; }
        }
        #endregion
        #region Costructores
        public clsDian()
        {
        }
        public clsDian(int ini, int fin)
        {
            this.Rango_Inicial = ini;
            this.Rango_Final = fin;
        }
        #endregion
    }
}
