using Matricula.Data;
using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Logic
{
    public static class CursoBL
    {
        public static List<Curso> Listar()
        {
            var cursoData = new CursosData();
            return cursoData.Listar();
        }
    }
}
