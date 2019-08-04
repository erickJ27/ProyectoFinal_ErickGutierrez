﻿using System;
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
using SistemaOdontologico.Registros;
namespace SistemaOdontologico.Registros
{
    public partial class rOdontologos : Form
    {
        public rOdontologos()
        {
            InitializeComponent();
            ListadoEspecialidades();
            EspecialidadComboBox.Text = null;
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            EspecialidadComboBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            FechaIngresoDateTimePicker.Value = DateTime.Now;
        }
        private Odontologos LlenarClase()
        {
            Odontologos odontologos = new Odontologos();

            odontologos.OdontologoId = (int)IdNumericUpDown.Value;
            odontologos.Nombres = NombresTextBox.Text;
            odontologos.Cedula = CedulaMaskedTextBox.Text;
            odontologos.Telefono = TelefonoMaskedTextBox.Text;
            odontologos.Celular = CelularMaskedTextBox.Text;
            odontologos.Especialidad = EspecialidadComboBox.Text;
            odontologos.Direccion = DireccionTextBox.Text;
            odontologos.Email = EmailTextBox.Text;
            odontologos.FechaIngreso = FechaIngresoDateTimePicker.Value;


            return odontologos;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Odontologos> db = new Repositorio<Odontologos>();
            Odontologos odontologos = db.Buscar((int)IdNumericUpDown.Value);

            return (odontologos != null);

        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, "El campo Nombre no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulaMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CedulaMaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulaMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "El campo Telefono no puede estar vacio");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelularMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CelularMaskedTextBox, "El campo Celular no puede estar vacio");
                CelularMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "El campo Direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "El campo Email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if(FechaIngresoDateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechaIngresoDateTimePicker, "No se puede registrar esta fecha.");
                paso = false;
            }

            return paso;
        }
        private void LlenarCampo(Odontologos odontologos)
        {
            IdNumericUpDown.Value = odontologos.OdontologoId;
            NombresTextBox.Text = odontologos.Nombres;
            CedulaMaskedTextBox.Text = odontologos.Cedula;
            TelefonoMaskedTextBox.Text = odontologos.Telefono;
            CelularMaskedTextBox.Text = odontologos.Celular;
            EspecialidadComboBox.Text = odontologos.Especialidad;
            DireccionTextBox.Text = odontologos.Direccion;
            EmailTextBox.Text = odontologos.Email;
            FechaIngresoDateTimePicker.Value = odontologos.FechaIngreso;

            
        }
        private void ListadoEspecialidades()
        {
            Repositorio<Especialidades> db = new Repositorio<Especialidades>(new DAL.CentroOdontologicoContexto());
            var listado = new List<Especialidades>();

            listado = db.GetList(p => true);
            EspecialidadComboBox.DataSource = listado;
            EspecialidadComboBox.DisplayMember = "Descripcion";
            EspecialidadComboBox.ValueMember = "EspecialidadId";

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Odontologos> db = new Repositorio<Odontologos>();
            Odontologos odontologos = new Odontologos();
            if (!Validar())
                return;

            odontologos = LlenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = db.Guardar(odontologos);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Odontologo que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(odontologos);
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

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Odontologos odontologos = new Odontologos();
            Repositorio<Odontologos> db = new Repositorio<Odontologos>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            odontologos = db.Buscar(id);

            if (odontologos != null)
            {
                LlenarCampo(odontologos);
            }
            else
                MessageBox.Show("Odontologo no encontrado");
        }

        private void NuevaEspecialidadButton_Click(object sender, EventArgs e)
        {
            rEspecialidades espe = new rEspecialidades();
            
            espe.StartPosition = FormStartPosition.CenterScreen;
            espe.ShowDialog();
            ListadoEspecialidades();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Odontologos> db = new Repositorio<Odontologos>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un Odontologo que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar un Odontologo que no existe");
        }

        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void CedulaMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void TelefonoMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void CelularMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
