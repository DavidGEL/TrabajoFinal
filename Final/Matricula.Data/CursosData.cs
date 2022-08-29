using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Matricula.Data
{
    public class CursosData
    {
        string cadenaConexion = "server=localhost; database=colegio; Integrated security=true";
        public List<Curso> Listar()
        {
            var listado = new List<Curso>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select * from Curso", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Curso curso;
                            while (lector.Read())
                            {
                                curso = new Curso();
                                curso.ID = int.Parse(lector[0].ToString());
                                curso.Nombre = lector[1].ToString();
                                listado.Add(curso);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Curso BuscarId(int id)
        {
            var curso = new Curso();
            return curso;
        }
        public bool Insertar(Curso curso)
        {
            return true;
        }
        public bool Actualizar(Curso curso)
        {
            return true;
        }
        public bool Eliminar(Curso curso)
        {
            return true;
        }
    }
}
