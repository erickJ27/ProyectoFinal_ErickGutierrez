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
namespace SistemaOdontologico.Registros
{
    public partial class rMateriales : Form
    {
        public rMateriales()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaNumericUpDown.Value = 0;
            CostoUNumericUpDown.Value = 0;
        }
        private Materiales LlenarClase()
        {
            Materiales m = new Materiales();
            m.MaterialId = (int)IdNumericUpDown.Value;
            m.Descripcion = DescripcionTextBox.Text;
            m.Existencia = (int)ExistenciaNumericUpDown.Value;
            m.CostoUnidad = CostoUNumericUpDown.Value;

            return m;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Materiales> db = new Repositorio<Materiales>();
            Materiales m = db.Buscar((int)IdNumericUpDown.Value);
            return (m != null);

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
            if (CostoUNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostoUNumericUpDown, "El campo Costo Unidad no puede estar vacio");
                CostoUNumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }
        private void LLenarCampo(Materiales m)
        {
            IdNumericUpDown.Value = m.MaterialId;
            DescripcionTextBox.Text = m.Descripcion;
            ExistenciaNumericUpDown.Value = m.Existencia;
            CostoUNumericUpDown.Value = m.CostoUnidad;

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Materiales> db = new Repositorio<Materiales>();
            Materiales m = new Materiales();
            if (!Validar())
                return;

            m = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = db.Guardar(m);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un material que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(m);
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
            Repositorio<Materiales> db = new Repositorio<Materiales>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un material que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar un material que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Materiales m = new Materiales();
            Repositorio<Materiales> db = new Repositorio<Materiales>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            m = db.Buscar(id);

            if (m != null)
            {
                LLenarCampo(m);
            }
            else
                MessageBox.Show("Material no encontrado");
        }
    }
}
