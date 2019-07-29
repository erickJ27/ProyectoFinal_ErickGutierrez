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
    public partial class Alergias : Form
    {
        public Alergias()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        //private Vacunas LlenarClase()
        //{
        //    Alergias vacunas = new Alergias();
        //    vacunas. = (int)IdNumericUpDown.Value;
        //    alergias.Descripcion = DescripcionTextBox.Text;
        //    return vacunas;
        //}
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
        //private void LLenarCampo(Alergias alergias)
        //{
        //    IdNumericUpDown.Value = alergias.VacunasId;
        //    DescripcionTextBox.Text = alergias.Descripcion;
        //}
        private void NuevoButton_Click(object sender, EventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
