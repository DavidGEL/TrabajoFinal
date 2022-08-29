using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Matricula.Data
{
    public class ProfesorData
    {
        string cadenaConexion = "server=localhost; database=colegio; Integrated security=true";
        public List<Profesor> Listar()
        {
            var listado = new List<Profesor>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select * from Profesor", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Profesor profesor;
                            while (lector.Read())
                            {
                                profesor = new Profesor();
                                profesor.ID = int.Parse(lector[0].ToString());
                                profesor.Nombres = lector[1].ToString();
                                profesor.Apellidos = lector[2].ToString();
                                profesor.Direccion = lector[3].ToString();
                                profesor.DNI = lector[4].ToString();
                                profesor.Correo = lector[5].ToString();
                                profesor.Celular = lector[6].ToString();
                                listado.Add(profesor);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Profesor BuscarId(int id)
        {
            var profesor = new Profesor();
            return profesor;
        }
        public bool Insertar(Profesor profesor)
        {
            return true;
        }
        public bool Actualizar(Profesor profesor)
        {
            return true;
        }
        public bool Eliminar(Profesor profesor)
        {
            return true;
        }
    }
}