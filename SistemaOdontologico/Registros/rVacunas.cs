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
    public partial class rVacunas : Form
    {
        public rVacunas()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        private Vacunas LlenarClase()
        {
            Vacunas vacunas = new Vacunas();
            vacunas.VacunasId = (int)IdNumericUpDown.Value;
            vacunas.Descripcion = DescripcionTextBox.Text;
            return vacunas;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Vacunas> db = new Repositorio<Vacunas>();
            Vacunas vacunas = db.Buscar((int)IdNumericUpDown.Value);

            return (vacunas != null);

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
        private void LLenarCampo(Vacunas vacunas)
        {
            IdNumericUpDown.Value = vacunas.VacunasId;
            DescripcionTextBox.Text = vacunas.Descripcion;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Vacunas> db = new Repositorio<Vacunas>();
            Vacunas v = new Vacunas();
            if (!Validar())
                return;

            v = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = db.Guardar(v);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Vacuna que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(v);
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
            Repositorio<Vacunas> db = new Repositorio<Vacunas>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar una vacuna que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar una vacuna que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Vacunas vacunas = new Vacunas();
            Repositorio<Vacunas> db = new Repositorio<Vacunas>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            vacunas = db.Buscar(id);

            if (vacunas != null)
            {
                LLenarCampo(vacunas);
            }
            else
                MessageBox.Show("Vacuna no encontrado");
        }
    }
}
