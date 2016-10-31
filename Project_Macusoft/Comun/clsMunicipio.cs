using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsMunicipio
    {
        //ATRIBUTOS
        private int id_municipio;
        private string nombre_munipio;


        //SET Y GET
        public string Nombre_munipio
        {
            get { return nombre_munipio; }
            set { nombre_munipio = value; }
        }

        public int Id_municipio
        {
            get { return id_municipio; }
            set { id_municipio = value; }
        }
        
        //CONSTRUCTOR VACIO

        public clsMunicipio() { 
        
        }
    
        //CONSTRUCTOR CON ARGUMENTOS

        public clsMunicipio(int id_municipio, string nombre_municipio) {

            this.Id_municipio = id_municipio;
            this.Nombre_munipio = nombre_municipio;
        }

        //public clsMunicipio(int id_municipio)
        //{
        //    this.Id_municipio = id_municipio;
        //}
    
    }
}
