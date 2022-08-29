using Matricula.Data;
using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Logic
{
    public static class AulaBL
    {
        public static List<Salon> Listar()
        {
            var aulaData = new AulaData();
            return aulaData.Listar();
        }
    }
}
