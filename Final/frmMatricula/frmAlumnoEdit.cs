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
    public partial class frmAlumnoEdit : Form
    {
        Alumno alumno;

        public frmAlumnoEdit(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            if (alumno.ID > 0)
            {
                asignarControles();
            }
        }
        private void cargarDatos()
        {
            cboCurso.DataSource = CursoBL.Listar();
            cboCurso.DisplayMember = "Nombre";//nombre
            cboCurso.ValueMember = "ID";//id
            /*--------------------------------------*/
            cboAula.DataSource = AulaBL.Listar();
            cboAula.DisplayMember = "Aula";//nombre
            cboAula.ValueMember = "ID";//id
            /*--------------------------------------*/
            cboProfesor.DataSource = ProfesorBL.Listar();
            cboProfesor.DisplayMember = "Nombres";//nombre
            cboProfesor.ValueMember = "ID";//id
        }

        private void GrabarDatos(object sender, EventArgs e)
        {
            asignarObejto();
            this.DialogResult = DialogResult.OK;
        }
        private void asignarObejto()
        {
            this.alumno.Nombres = txtNombre.Text;
            this.alumno.Apellidos = txtApellidos.Text;
            this.alumno.Direccion = txtDireccion.Text;
            this.alumno.DNI = txtDni.Text;
            this.alumno.Correo = txtCorreo.Text;
            this.alumno.Celular = txtCelular.Text;
            this.alumno.IdCurso = int.Parse(cboCurso.SelectedValue.ToString());
            this.alumno.IdAula = int.Parse(cboAula.SelectedValue.ToString());
            this.alumno.IdProfesor = int.Parse(cboProfesor.SelectedValue.ToString());
        }
        private void asignarControles()
        {
            txtNombre.Text = alumno.Nombres;
            txtApellidos.Text = alumno.Apellidos;
            txtDireccion.Text = alumno.Direccion;
            txtDni.Text = alumno.DNI;
            txtCorreo.Text = alumno.Correo;
            txtCelular.Text = alumno.Celular;
            cboCurso.SelectedValue = alumno.IdCurso;
            cboAula.SelectedValue = alumno.IdAula;
            cboProfesor.SelectedValue = alumno.IdProfesor;
        }
    }
}