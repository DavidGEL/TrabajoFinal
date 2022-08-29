using Matricula.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Matricula.Data
{
    public class AulaData
    {
        string cadenaConexion = "server=localhost; database=colegio; Integrated security=true";
        public List<Salon> Listar()
        {
            var listado = new List<Salon>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select * from Aula", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Salon salon;
                            while (lector.Read())
                            {
                                salon = new Salon();
                                salon.ID = int.Parse(lector[0].ToString());
                                salon.Aula = lector[1].ToString();
                                listado.Add(salon);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Salon BuscarId(int id)
        {
            var salon = new Salon();
            return salon;
        }
        public bool Insertar(Salon salon)
        {
            return true;
        }
        public bool Actualizar(Salon salon)
        {
            return true;
        }
        public bool Eliminar(Alumno alumno)
        {
            return true;
        }
    }
}
