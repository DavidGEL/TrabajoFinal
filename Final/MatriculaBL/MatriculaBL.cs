using Matricula.Data;
using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Logic
{
    public static class MatriculaBL
    {

        public static List<Alumno> Listar()
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Listar();
        }
        public static Alumno BuscarPorId(int id)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.BuscarId(id);
        }
        public static bool Actualizar(Alumno alumno)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Actualizar(alumno);
        }
        public static bool Insertar(Alumno alumno)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Insertar(alumno);
        }
        public static bool Eliminar(int id)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Eliminar(id);
        }
    }
}
