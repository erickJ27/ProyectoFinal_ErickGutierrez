using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace SistemaOdontologico.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NivelUsuarioComboBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            FechaIngresoDateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }
        private Usuarios LlenarClase()
        {

            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(IdNumericUpDown.Value);
            usuario.Nombres = NombresTextBox.Text;
            usuario.Email = EmailTextBox.Text;

            if (NivelUsuarioComboBox.SelectedIndex == 0)
                usuario.NivelUsuario = 1;
            else
                usuario.NivelUsuario = 2;

            usuario.Usuario = UsuarioTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.FechaIngreso = FechaIngresoDateTimePicker.Value;

            return usuario;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>();
            Usuarios usuarios = db.Buscar((int)IdNumericUpDown.Value);

            return (usuarios != null);

        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (NombresTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombresTextBox, "El campo Nombre no puede estar vacio");
                NombresTextBox.Focus();

                paso = false;
            }
            if (EmailTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(EmailTextBox, "El campo Email no puede estar vacio");
                EmailTextBox.Focus();

                paso = false;
            }
            if (NombresTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombresTextBox, "El campo Nombre no puede estar vacio");
                NombresTextBox.Focus();

                paso = false;
            }
            if (ClaveTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(ClaveTextBox, "El campo Clave no puede estar vacio");
                ClaveTextBox.Focus();

                paso = false;
            }

            return paso;
        }
        private void LlenarCampo(Usuarios usuarios)
        {
            IdNumericUpDown.Value = usuarios.UsuarioId;
            NombresTextBox.Text = usuarios.Nombres;
            EmailTextBox.Text = usuarios.Email;

            string adm = "Administrador";
            string sur = "Supervisor";

            if (usuarios.NivelUsuario == 1)
                NivelUsuarioComboBox.Text = adm;
            else
                NivelUsuarioComboBox.Text = sur;

            UsuarioTextBox.Text = usuarios.Usuario;
            ClaveTextBox.Text = usuarios.Clave;
            FechaIngresoDateTimePicker.Value = usuarios.FechaIngreso;

        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Usuarios> db = new Repositorio<Usuarios>();
            Usuarios usuarios = new Usuarios();
            if (!Validar())
                return;

            usuarios = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = db.Guardar(usuarios);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(usuarios);
            }
            if (!ExisteEnLaBaseDeDatos())
            {
                if (paso)
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (paso)
                    MessageBox.Show("Modificado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar una asignatura que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar una asignatura que no existe");


        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuarios = new Usuarios();
            Repositorio<Usuarios> db = new Repositorio<Usuarios>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            usuarios = db.Buscar(id);

            if (usuarios != null)
            {
                LlenarCampo(usuarios);
            }
            else
                MessageBox.Show("Usuario no encontrado");
        }
    }
}
