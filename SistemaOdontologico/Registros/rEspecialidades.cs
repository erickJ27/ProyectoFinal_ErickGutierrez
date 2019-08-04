using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using DAL;

namespace SistemaOdontologico.Registros
{
    public partial class rEspecialidades : Form
    {
        public rEspecialidades()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        private Especialidades LlenarClase()
        {
            Especialidades especialidades = new Especialidades();
            especialidades.EspecialidadId = (int)IdNumericUpDown.Value;
            especialidades.Descripcion = DescripcionTextBox.Text;
            return especialidades;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Especialidades> db = new Repositorio<Especialidades>();
            Especialidades especialidades = db.Buscar((int)IdNumericUpDown.Value);

            return (especialidades != null);

        }
        public static bool RepetirEspecialidad(string descripcion)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();

            try
            {
                if (db.Especialidades.Any(p => p.Descripcion.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool ValidarRepetir()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (RepetirEspecialidad(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "No se puede crear una especialidad mas de 1 veces.");
                paso = false;
            }
            return paso;
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "El campo Descripcion no puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void LLenarCampo(Especialidades especialidades)
        {
            IdNumericUpDown.Value = especialidades.EspecialidadId;
            DescripcionTextBox.Text = especialidades.Descripcion;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Especialidades> db = new Repositorio<Especialidades>();
            Especialidades especialidades = new Especialidades();
            if (!Validar())
                return;

            especialidades = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                if (!ValidarRepetir())
                    return;
                paso = db.Guardar(especialidades);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una especialidad que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(especialidades);
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
            Repositorio<Especialidades> db = new Repositorio<Especialidades>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar una especialidad que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar una especialidad que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;
            Especialidades especialidades = new Especialidades();
            Repositorio<Especialidades> db = new Repositorio<Especialidades>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            especialidades = db.Buscar(id);

            if (especialidades != null)
            {
                LLenarCampo(especialidades);
            }
            else
                MessageBox.Show("Especialidad no encontrado");
        }

        
    }
}
