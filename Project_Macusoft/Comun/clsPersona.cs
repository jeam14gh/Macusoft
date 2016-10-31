using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun
{
    public abstract class clsPersona
    {
        #region ATRIBUTOS
        private string nombre;
        private string apellidos;
        private string direccion;
        private string telefono;
        private string n_documento;
        private DateTime fecha_nacimiento;
        private string email;
        private string tipo_documento;
        private clsMunicipio municipio;
        private clsDepartamento departamento;
        private DateTime fecha_registro;
        #endregion

        #region SET Y GET
        public DateTime Fecha_registro
        {
            get { return fecha_registro; }
            set { fecha_registro = value; }
        }

        public clsDepartamento Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public clsMunicipio Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        public string Tipo_documento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }
       
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime Fecha_nacimiento
        {
            get { return fecha_nacimiento; }
            set { fecha_nacimiento = value; }
        }

        public string N_documento
        {
            get { return n_documento; }
            set { n_documento = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion
    
        //CONSTRUTOR  VACIO

        public clsPersona() 
        {  }


        //CONSTRUTOR CON ARGUMENTOS

        public clsPersona (string nombre, string apellidos, string direccion, string telefono, string n_documento,
                           DateTime fecha_nacimiento, string email, string tipo_documento, clsMunicipio municipio, clsDepartamento departamneto, DateTime fecha_registro)
        {

        this.Nombre = nombre;
        this.Apellidos = apellidos;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.N_documento = n_documento;
        this.Fecha_nacimiento = fecha_nacimiento;
        this.Email = email;
        this.Tipo_documento = tipo_documento;
        this.Municipio = municipio;
        this.Departamento = departamneto;
        this.Fecha_registro = fecha_registro;
        }

    }
}
