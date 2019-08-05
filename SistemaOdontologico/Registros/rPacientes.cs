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
    public partial class rPacientes : Form
    {
        public List<PacienteAlergias> Detalle1 { get; set; }
        public List<PacienteVacunas> Detalle2 { get; set; }
        public rPacientes()
        {
            InitializeComponent();
            this.Detalle1 = new List<PacienteAlergias>();
            this.Detalle2 = new List<PacienteVacunas>();
            ListadoAlergias();
            ListadoVacunas();
            NombreAlergiaComboBox.Text = null;
            NombreVacunaComboBox.Text = null;
            
        }
        private void CargarGrid1()
        {
            AlergiasDataGridView.DataSource = null;
            AlergiasDataGridView.DataSource = this.Detalle1;
            
        }
        private void CargarGrid2()
        {
            VacunasDataGridView.DataSource = null;
            VacunasDataGridView.DataSource = this.Detalle2;
        }


        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            SexoComboBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            GrupoSangineoComboBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            SeguroMedicoComboBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ObservacionTextBox.Text = string.Empty;
            FechaIngresoDateTimePicker.Text = string.Empty;
            this.Detalle1 = new List<PacienteAlergias>();
            this.Detalle2 = new List<PacienteVacunas>();

            CargarGrid1();
            CargarGrid2();
            MyErrorProvider.Clear();
        }
        private void ListadoVacunas()
        {
            Repositorio<Vacunas> db = new Repositorio<Vacunas>(new DAL.CentroOdontologicoContexto());
            var lista = new List<Vacunas>();
            lista = db.GetList(l => true);
            NombreVacunaComboBox.DataSource = lista;
            NombreVacunaComboBox.DisplayMember = "Descripcion";
            NombreVacunaComboBox.ValueMember = "VacunasId";
        }
        private void ListadoAlergias()
        {
            Repositorio<Alergias> db = new Repositorio<Alergias>(new DAL.CentroOdontologicoContexto());
            var lista = new List<Alergias>();
            lista = db.GetList(l => true);
            NombreAlergiaComboBox.DataSource = lista;
            NombreAlergiaComboBox.DisplayMember = "Descripcion";
            NombreAlergiaComboBox.ValueMember = "AlergiasId";
        }

        private Pacientes LLenarClase()
        {
            Pacientes pacientes = new Pacientes();
            pacientes.PacienteID = (int)IdNumericUpDown.Value;
            pacientes.Nombres = NombresTextBox.Text;
            pacientes.Sexo = SexoComboBox.Text;
            pacientes.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            pacientes.GrupoSanguineo = GrupoSangineoComboBox.Text;
            pacientes.Cedula = CedulaMaskedTextBox.Text;
            pacientes.Telefono = TelefonoMaskedTextBox.Text;
            pacientes.Celular = CelularMaskedTextBox.Text;
            pacientes.Cedula = CedulaMaskedTextBox.Text;
            pacientes.SeguroMedico = SeguroMedicoComboBox.Text;
            pacientes.Direccion = DireccionTextBox.Text;
            pacientes.Email = EmailTextBox.Text;
            pacientes.ObservacionPacientes = ObservacionTextBox.Text;
            pacientes.FechaIngreso = FechaIngresoDateTimePicker.Value;

            pacientes.Alergias = this.Detalle1;
            pacientes.Vacunas = this.Detalle2;

            return pacientes;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Pacientes> db = new Repositorio<Pacientes>(new DAL.CentroOdontologicoContexto());
            Pacientes pacientes = db.Buscar((int)IdNumericUpDown.Value);
            return (pacientes != null);

        }
        private void LlenarCampo(Pacientes pacientes)
        {
            IdNumericUpDown.Value = pacientes.PacienteID;
            NombresTextBox.Text = pacientes.Nombres;
            SexoComboBox.Text = pacientes.Sexo;
            FechaNacimientoDateTimePicker.Value = pacientes.FechaNacimiento;
            GrupoSangineoComboBox.Text = pacientes.GrupoSanguineo;
            CedulaMaskedTextBox.Text = pacientes.Cedula;
            TelefonoMaskedTextBox.Text = pacientes.Telefono;
            CelularMaskedTextBox.Text = pacientes.Celular;
            SeguroMedicoComboBox.Text = pacientes.SeguroMedico;
            DireccionTextBox.Text = pacientes.Direccion;
            EmailTextBox.Text = pacientes.Email;
            ObservacionTextBox.Text = pacientes.ObservacionPacientes;
            FechaIngresoDateTimePicker.Value = pacientes.FechaIngreso;

            Detalle1 = new List<PacienteAlergias>();
            this.Detalle1 = pacientes.Alergias;
            Detalle2 = new List<PacienteVacunas>();
            this.Detalle2 = pacientes.Vacunas;

            CargarGrid1();
            CargarGrid2();
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, "El campo Nombres no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            
            
            if (string.IsNullOrWhiteSpace(GrupoSangineoComboBox.Text))
            {
                MyErrorProvider.SetError(GrupoSangineoComboBox, "El campo GrupoSangineo no puede estar vacio");
                GrupoSangineoComboBox.Focus();
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
            if (string.IsNullOrWhiteSpace(SeguroMedicoComboBox.Text))
            {
                MyErrorProvider.SetError(SeguroMedicoComboBox, "El campo Seguro Medico no puede estar vacio");
                SeguroMedicoComboBox.Focus();
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
                MyErrorProvider.SetError(EmailTextBox, "El campo Seguro Medico no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ObservacionTextBox.Text))
            {
                MyErrorProvider.SetError(ObservacionTextBox, "El campo Seguro Medico no puede estar vacio");
                ObservacionTextBox.Focus();
                paso = false;
            }
            if (FechaNacimientoDateTimePicker.Value > FechaIngresoDateTimePicker.Value)
            {
                MyErrorProvider.SetError(FechaNacimientoDateTimePicker, "No se puede registrar esta fecha.");
                FechaNacimientoDateTimePicker.Focus();
                paso = false;
            }
            if (FechaIngresoDateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechaIngresoDateTimePicker, "No se puede registrar esta fecha.");
                FechaIngresoDateTimePicker.Focus();
                paso = false;
            }


            return paso;
        }
        public string id_vacu;
        private bool ExisteEnGridVacunas()
        {

            bool paso = true;

            if (VacunasDataGridView.RowCount > 0)
            {
                id_vacu = NombreVacunaComboBox.SelectedValue.ToString();
                for (int i = 0; i < VacunasDataGridView.RowCount; i++)
                {
                    if (Convert.ToInt16(VacunasDataGridView.Rows[i].Cells["Id"].Value) == Convert.ToInt16(id_vacu))
                    {
                        MessageBox.Show("La vacuna ya ha sido ingresado");
                        paso = false;

                    }
                }

            }

            return paso;

        }
        public string id_ale;
        private bool ExisteEnGridAlergias()
        {

            bool paso = true;

            if (AlergiasDataGridView.RowCount > 0)
            {
                id_ale = NombreAlergiaComboBox.SelectedValue.ToString();
                for (int i = 0; i < AlergiasDataGridView.RowCount; i++)
                {
                    if (Convert.ToInt16(AlergiasDataGridView.Rows[i].Cells["Id"].Value) == Convert.ToInt16(id_ale))
                    {
                        MessageBox.Show("La Alergia ya ha sido ingresado");
                        paso = false;

                    }
                }

            }

            return paso;

        }

        private void AlergiasButton_Click(object sender, EventArgs e)
        {

            List<PacienteAlergias> detalles = new List<PacienteAlergias>();
            Repositorio<Pacientes> db = new Repositorio<Pacientes>(new DAL.CentroOdontologicoContexto());
            if(AlergiasDataGridView.DataSource != null)
                this.Detalle1 = (List<PacienteAlergias>)AlergiasDataGridView.DataSource;
            if (NombreAlergiaComboBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreAlergiaComboBox, "No a seleccionado una Alergia");
                NombreAlergiaComboBox.Focus();
                return;
            }

            if (ExisteEnGridAlergias() == false)
            {
                MyErrorProvider.SetError(NombreAlergiaComboBox, "La alergia ya existe en el Grid");
                NombreAlergiaComboBox.Focus();

                return;
            }

            this.Detalle1.Add(new PacienteAlergias()
            {
                Id = (int)NombreAlergiaComboBox.SelectedValue,
                PacienteId = (int)IdNumericUpDown.Value,
                Descripcion = NombreAlergiaComboBox.Text
            });

            CargarGrid1();
            NombreAlergiaComboBox.Text = string.Empty;
        }

        private void EliminarAlergiaButton_Click(object sender, EventArgs e)
        {
          if (AlergiasDataGridView.Rows.Count > 0 && AlergiasDataGridView.CurrentRow != null)
          {
                Detalle1.RemoveAt(AlergiasDataGridView.CurrentRow.Index);
                CargarGrid1();
          }
            
        }

        private void VacunasButton_Click(object sender, EventArgs e)
        {
            
            List<PacienteVacunas> detalles = new List<PacienteVacunas>();
            Repositorio<Pacientes> db = new Repositorio<Pacientes>(new DAL.CentroOdontologicoContexto());
            if (VacunasDataGridView.DataSource != null)
                this.Detalle2 = (List<PacienteVacunas>)VacunasDataGridView.DataSource;

            if (NombreVacunaComboBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreVacunaComboBox, "No a seleccionado una Vacuna");
                NombreVacunaComboBox.Focus();
                return;
            }

            if (ExisteEnGridVacunas() == false)
            {
                MyErrorProvider.SetError(NombreVacunaComboBox, "La vacuna ya existe en el Grid");
                NombreVacunaComboBox.Focus();

                return;
            }

            this.Detalle2.Add(new PacienteVacunas()
            {
                Id = (int)NombreVacunaComboBox.SelectedValue,
                PacienteId = (int)IdNumericUpDown.Value,
                Descripcion = NombreVacunaComboBox.Text
            });

            CargarGrid2();
            NombreVacunaComboBox.Text = string.Empty;
        }

        private void EliminarVacunaButton_Click(object sender, EventArgs e)
        {
            if (VacunasDataGridView.Rows.Count > 0 && VacunasDataGridView.CurrentRow != null)
            {
                Detalle2.RemoveAt(VacunasDataGridView.CurrentRow.Index);
                CargarGrid2();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Pacientes> db = new Repositorio<Pacientes>();
            Pacientes pacientes = new Pacientes();
            if (!Validar())
                return;

            pacientes = LLenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = db.Guardar(pacientes);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un paciente que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(pacientes);
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
            Repositorio<Pacientes> db = new Repositorio<Pacientes>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un paciente que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar un paciente que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Pacientes pacientes = new Pacientes();
            Repositorio<Pacientes> db = new Repositorio<Pacientes>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            pacientes = db.Buscar(id);

            if (pacientes != null)
            {
                LlenarCampo(pacientes);
            }
            else
                MessageBox.Show("Pacientes no encontrado");
        }

        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
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

        private void NombreAlergiaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
        }

        private void NombreVacunaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
        }
    }
}
