using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public class clsDepartamento
    {
    
        //ATRIBUTOS
        private byte id_departamento;
        private string nombre_departamento;


        //SET Y GET
        public string Nombre_departamento
        {
            get { return nombre_departamento; }
            set { nombre_departamento = value; }
        }

        public byte Id_departamento
        {
            get { return id_departamento; }
            set { id_departamento = value; }
        }
        
        //CONSTRUCTOR VACIO

        public clsDepartamento() { }
    
        //CONSTRUCTOR CON ARGUMENTOS

        public clsDepartamento(byte id_departamento, string nombre_departamento)
        {

            this.Id_departamento = id_departamento;
            this.Nombre_departamento = nombre_departamento;
        }
    
    
    
    
    }
}
