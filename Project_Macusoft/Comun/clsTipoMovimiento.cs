using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsTipoMovimiento
    {
        private int id_TipoMovimiento;        
        private string descripcion_movimiento;        
        private int dian_inicio;        
        private int dian_final;        

        #region get y set
        public int Id_TipoMovimiento
        {
            get { return id_TipoMovimiento; }
            set { id_TipoMovimiento = value; }
        }

        public string Descripcion_movimiento
        {
            get { return descripcion_movimiento; }
            set { descripcion_movimiento = value; }
        }

        public int Dian_inicio
        {
            get { return dian_inicio; }
            set { dian_inicio = value; }
        }

        public int Dian_final
        {
            get { return dian_final; }
            set { dian_final = value; }
        }
        #endregion

        //Constructor vacio
        public clsTipoMovimiento() { }

        public clsTipoMovimiento(int idTipMov,string des_mov, int dian_ini, int dian_fin)
        {
            this.Id_TipoMovimiento = idTipMov;
            this.Descripcion_movimiento = des_mov;
            this.Dian_inicio = dian_ini;
            this.Dian_final = dian_fin;
        }
    }
}
