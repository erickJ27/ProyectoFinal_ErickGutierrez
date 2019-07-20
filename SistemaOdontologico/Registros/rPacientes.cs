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
            MasculinoRadioButton.Checked = false;
            FemeninoRadioButton.Checked = false;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            GrupoSangineoComboBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            SeguroMedicoComboBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ObservacionTextBox.Text = string.Empty;
            FechaIngresoDateTimePicker.Text = string.Empty;
            this.Detalle1 = new List<PacienteAlergias>();
            this.Detalle2 = new List<PacienteVacunas>();

            CargarGrid1();
            CargarGrid2();
        }

        private Pacientes LLenarClase()
        {
            Pacientes pacientes = new Pacientes();
            pacientes.PacienteID = (int)IdNumericUpDown.Value;
            pacientes.Nombres = NombresTextBox.Text;

            if (MasculinoRadioButton.Checked == true)
            {
                pacientes.Sexo = 'M';
            }
            if (FemeninoRadioButton.Checked == true)
            {
                pacientes.Sexo = 'F';
            }

            pacientes.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            pacientes.GrupoSanguineo = GrupoSangineoComboBox.Text;
            pacientes.Cedula = CedulaTextBox.Text;
            pacientes.Telefono = TelefonoTextBox.Text;
            pacientes.Celular = CelularTextBox.Text;
            pacientes.Cedula = CelularTextBox.Text;
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

            if (pacientes.Sexo == 'M')
                MasculinoRadioButton.Checked = true;
            else
                FemeninoRadioButton.Checked = true;

            FechaNacimientoDateTimePicker.Value = pacientes.FechaNacimiento;
            GrupoSangineoComboBox.Text = pacientes.GrupoSanguineo;
            CedulaTextBox.Text = pacientes.Cedula;
            TelefonoTextBox.Text = pacientes.Telefono;
            CelularTextBox.Text = pacientes.Celular;
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
            /*if (MasculinoRadioButton.Checked == false   || FemeninoRadioButton.Checked == false)
            {
                MyErrorProvider.SetError(FemeninoRadioButton, "Seleccione una Sexo");
                MasculinoRadioButton.Focus();
                FemeninoRadioButton.Focus();
                paso = false;
            }*/
            if (string.IsNullOrWhiteSpace(GrupoSangineoComboBox.Text))
            {
                MyErrorProvider.SetError(GrupoSangineoComboBox, "El campo GrupoSangineo no puede estar vacio");
                GrupoSangineoComboBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                MyErrorProvider.SetError(CedulaTextBox, "El campo Cedula no puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonoTextBox, "El campo Telefono no puede estar vacio");
                TelefonoTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelularTextBox.Text))
            {
                MyErrorProvider.SetError(CelularTextBox, "El campo Celular no puede estar vacio");
                CelularTextBox.Focus();
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
            

            return paso;
        }

        private void AlergiasButton_Click(object sender, EventArgs e)
        {
            List<PacienteAlergias> detalles = new List<PacienteAlergias>();
            Repositorio<Pacientes> db = new Repositorio<Pacientes>(new DAL.CentroOdontologicoContexto());
            if(AlergiasDataGridView.DataSource != null)
            this.Detalle1 = (List<PacienteAlergias>)AlergiasDataGridView.DataSource;

            this.Detalle1.Add(new PacienteAlergias()
            {
                Id = 0,
                PacienteId = (int)IdNumericUpDown.Value,
                Descripcion = NombreAlergiaTextBox.Text
            });

            CargarGrid1();
            NombreAlergiaTextBox.Text = string.Empty;
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

            this.Detalle2.Add(new PacienteVacunas()
            {
                Id = 0,
                PacienteId = (int)IdNumericUpDown.Value,
                Descripcion = NombreVacunaTextBox.Text
            });

            CargarGrid2();
            NombreVacunaTextBox.Text = string.Empty;
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
    }
}
