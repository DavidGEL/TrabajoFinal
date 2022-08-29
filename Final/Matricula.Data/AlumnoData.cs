
using System.Collections.Generic;
using System.Data.SqlClient;
using Matricula.Dominio;

namespace Matricula.Data
{
    public class AlumnoData
    {
        string cadenaConexion = "server=localhost; database=colegio; Integrated security=true";
        public List<Alumno> Listar()
        {
            var listado = new List<Alumno>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select * from Alumno", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if(lector!=null && lector.HasRows)
                        {
                            Alumno alumno;
                            while (lector.Read())
                            {
                                alumno = new Alumno();
                                alumno.ID = int.Parse(lector[0].ToString());
                                alumno.Nombres = lector[1].ToString();
                                alumno.Apellidos = lector[2].ToString();
                                alumno.Direccion = lector[3].ToString();
                                alumno.DNI = lector[4].ToString();
                                alumno.Correo = lector[5].ToString();
                                alumno.Celular = lector[6].ToString();
                                alumno.IdCurso = int.Parse(lector[7].ToString());
                                alumno.IdAula = int.Parse(lector[8].ToString());
                                alumno.IdProfesor = int.Parse(lector[9].ToString());
                                listado.Add(alumno);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Alumno BuscarId(int id)
        {
            Alumno alumno = new Alumno();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select *from Alumno WHERE ID =@id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            alumno = new Alumno();
                            alumno.ID = int.Parse(lector[0].ToString());
                            alumno.Nombres = lector[1].ToString();
                            alumno.Apellidos = lector[2].ToString();
                            alumno.Direccion = lector[3].ToString();
                            alumno.DNI = lector[4].ToString();
                            alumno.Correo = lector[5].ToString();
                            alumno.Celular = lector[6].ToString();
                            alumno.IdCurso = int.Parse(lector[7].ToString());
                            alumno.IdAula = int.Parse(lector[8].ToString());
                            alumno.IdProfesor = int.Parse(lector[9].ToString());
                        }
                    }
                }
            }
            return alumno;
        }
        public bool Insertar(Alumno alumno)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Alumno (Nombres, Apellidos, " +                                "Direccion, DNI, Correo, Celular, " +                                "IdCurso, IdAula,IdProfesor)" +                            "VALUES(@Nombres, @Apellidos, @Direccion, @DNI, " +                                "@Correo,@Celular, @IdCurso, @IdAula,@IdProfesor)";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                    comando.Parameters.AddWithValue("@Direccion", alumno.Direccion);
                    comando.Parameters.AddWithValue("@DNI", alumno.DNI);
                    comando.Parameters.AddWithValue("@Correo", alumno.Correo);
                    comando.Parameters.AddWithValue("@Celular", alumno.Celular);
                    comando.Parameters.AddWithValue("@IdCurso", alumno.IdCurso);
                    comando.Parameters.AddWithValue("@IdAula", alumno.IdAula);
                    comando.Parameters.AddWithValue("@IdProfesor", alumno.IdProfesor);
                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;
        }
        public bool Actualizar(Alumno alumno)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Alumno SET Nombres = @Nombres, Apellidos = @Apellidos, " +
                   "Direccion = @Direccion, DNI = @DNI, " +
                   "Correo = @Correo, Celular = @Celular, " +
                   "IdCurso = @IdCurso, IdAula = @IdAula, IdProfesor=@IdProfesor " +
                   "WHERE ID = @id";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                    comando.Parameters.AddWithValue("@Direccion", alumno.Direccion);
                    comando.Parameters.AddWithValue("@DNI", alumno.DNI);
                    comando.Parameters.AddWithValue("@Correo", alumno.Correo);
                    comando.Parameters.AddWithValue("@Celular", alumno.Celular);
                    comando.Parameters.AddWithValue("@IdCurso", alumno.IdCurso);
                    comando.Parameters.AddWithValue("@IdAula", alumno.IdAula);
                    comando.Parameters.AddWithValue("@IdProfesor", alumno.IdProfesor);
                    comando.Parameters.AddWithValue("@id", alumno.ID);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }
        public bool Eliminar(int id)
        {
            int filasEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "delete from Alumno WHERE ID = @ID";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);
                    filasEliminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEliminadas > 0;
        }
    }
}