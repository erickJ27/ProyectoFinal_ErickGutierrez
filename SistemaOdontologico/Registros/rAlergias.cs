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
using DAL;

namespace SistemaOdontologico.Registros
{
    public partial class rAlergias : Form
    {
        public rAlergias()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        private Alergias LlenarClase()
        {
            Alergias alergias = new Alergias();
            alergias.AlergiasId = (int)IdNumericUpDown.Value;
            alergias.Descripcion = DescripcionTextBox.Text;
            return alergias;
        }
        
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Alergias> db = new Repositorio<Alergias>();
            Alergias alergias = db.Buscar((int)IdNumericUpDown.Value);

            return (alergias != null);

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
        private void LLenarCampo(Alergias alergias)
        {
            IdNumericUpDown.Value = alergias.AlergiasId;
            DescripcionTextBox.Text = alergias.Descripcion;
        }
        public static bool RepetirAlergias(string descripcion)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();

            try
            {
                if (db.Alergias.Any(p => p.Descripcion.Equals(descripcion)))
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

            if (RepetirAlergias(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "No se puede crear una alergia mas de 1 veces.");
                DescripcionTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
           int id;
            Alergias alergias = new Alergias();
            Repositorio<Alergias> db = new Repositorio<Alergias>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            alergias = db.Buscar(id);

            if (alergias != null)
            {
                LLenarCampo(alergias);
            }
            else
                MessageBox.Show("alergia no encontrado");  
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Alergias> db = new Repositorio<Alergias>();
            Alergias A = new Alergias();
            if (!Validar())
                return;

            A = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                if (!ValidarRepetir())
                    return;
                paso = db.Guardar(A);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Alergia que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(A);
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
            Repositorio<Alergias> db = new Repositorio<Alergias>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar una alergia que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar una alergia que no existe");
        }

        private void DescripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
