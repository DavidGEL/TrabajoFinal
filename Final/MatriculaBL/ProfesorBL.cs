using Matricula.Data;
using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Logic
{
    public static class ProfesorBL
    {
        public static List<Profesor> Listar()
        {
            var profesorData = new ProfesorData();
            return profesorData.Listar();
        }
    }
}
