using Matricula.Dominio;
using Matricula.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMatricula
{
    public partial class frmMatricula : Form
    {
        public frmMatricula()
        {
            InitializeComponent();
        }

        private void frmMatricula_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = MatriculaBL.Listar();
            dgvDatos.Rows.Clear();
            foreach (var alumno in listado)
            {
                dgvDatos.Rows.Add(alumno.ID, alumno.NombreCompleto, alumno.Direccion, alumno.DNI, alumno.Correo
                    , alumno.Celular, alumno.IdCurso, alumno.IdAula, alumno.IdProfesor);
            }
        }
        private void NuevoRegistro(object sender, EventArgs e)
        {
            var nuevoAlumno = new Alumno();
            var frm = new frmAlumnoEdit(nuevoAlumno);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = MatriculaBL.Insertar(nuevoAlumno);
                if (exito)
                {
                    MessageBox.Show("El Alumno ha sido registrado correctamente", "Matricula",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("El Alumno no se ha registrado", "Matricula",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarRegistro(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                int filaAcutal = dgvDatos.CurrentRow.Index;
                var idAlumno = int.Parse(dgvDatos.Rows[filaAcutal].Cells[0].Value.ToString());
                var AlumnoEditar = MatriculaBL.BuscarPorId(idAlumno);
                var frm = new frmAlumnoEdit(AlumnoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = MatriculaBL.Actualizar(AlumnoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El Alumno ha sido Actualizado correctamente", "Matricula",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("El Alumno no se ha Actualizado", "Matricula",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                int filaActual = dgvDatos.CurrentRow.Index;
                var idAlumno = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var NombreAlumno = dgvDatos.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar al Alumno " + NombreAlumno + "?", "Matricula",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = MatriculaBL.Eliminar(idAlumno);
                    if (exito)
                    {
                        MessageBox.Show("El Alumno ha sido eliminado", "Matricula", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}