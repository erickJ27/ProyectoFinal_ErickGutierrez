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
        //private Alergias LlenarClase()
        //{
        //    Alergias alergias = new Alergias();
        //   / alergias = (int)IdNumericUpDown.Value;
        //    //vacunas.Descripcion = DescripcionTextBox.Text;
        //    //return vacunas;
        //}
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

        }
    }
}
