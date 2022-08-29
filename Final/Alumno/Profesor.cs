using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Dominio
{
    public class Profesor
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public string NombreCompleto
        {
            get
            {
                return this.Nombres + " " + this.Apellidos;
            }
        }
    }
}
