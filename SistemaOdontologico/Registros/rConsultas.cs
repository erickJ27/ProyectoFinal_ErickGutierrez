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
    public partial class rConsultas : Form
    {
        public List<MaterialesDetalle> Detalle { get; set; }
        public rConsultas()
        {
            this.Detalle = new List<MaterialesDetalle>();
            InitializeComponent();
        }
        private void CargarGrid()
        {
            MaterialesDataGridView.DataSource = null;
            MaterialesDataGridView.DataSource = this.Detalle;

        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            PacienteComboBox.Text = string.Empty;
            OdontologoComboBox.Text = string.Empty;
            FechaActualDateTimePicker.Value = DateTime.Now;
            FechaConsultaProximaDateTimePicker.Value = DateTime.Now;
            DiagnosticoTextBox.Text = string.Empty;
            ObservacionTextBox.Text = string.Empty;
            TratamientoTextBox.Text = string.Empty;
            MaterialesComboBox.Text = string.Empty;
            CantidadNumericUpDown.Value = 0;
            Detalle = new List<MaterialesDetalle>();
            CargarGrid();
        }
        private ConsultasM LLenarClase()
        {
            ConsultasM c = new ConsultasM();
            c.ConsultaId = (int)IdNumericUpDown.Value;
            c.PacienteId = (int)PacienteComboBox.SelectedValue;
            c.OdontologoId = (int)OdontologoComboBox.SelectedValue;
            c.FechaActual = FechaActualDateTimePicker.Value;
            c.FechaConsultaProxima = FechaConsultaProximaDateTimePicker.Value;
            c.Materiales = this.Detalle;
            c.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text) ;
            c.Itbis = Convert.ToDecimal(ItbisTextBox.Text);
            c.Total = Convert.ToDecimal(TotalTextBox.Text);
            c.Diagnostico = DiagnosticoTextBox.Text;
            c.Observacion = ObservacionTextBox.Text;
            c.Tratamiento = TratamientoTextBox.Text;

            return c;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<ConsultasM> db = new Repositorio<ConsultasM>(new DAL.CentroOdontologicoContexto());
            ConsultasM c = db.Buscar((int)IdNumericUpDown.Value);
            return (c != null);

        }
        private void LLenarCampo(ConsultasM c)
        {
            IdNumericUpDown.Value = c.ConsultaId;
            PacienteComboBox.Text = c.PacienteId.ToString();
            OdontologoComboBox.Text = c.OdontologoId.ToString();
            FechaActualDateTimePicker.Value = c.FechaActual;
            FechaConsultaProximaDateTimePicker.Value = c.FechaConsultaProxima;
            this.Detalle = c.Materiales;
            SubTotalTextBox.Text = Convert.ToString(c.SubTotal);
            ItbisTextBox.Text = Convert.ToString(c.Itbis);
            TotalTextBox.Text = Convert.ToString(c.Total);
            DiagnosticoTextBox.Text = c.Diagnostico;
            ObservacionTextBox.Text = c.Observacion;
            TratamientoTextBox.Text = c.Tratamiento;


        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {

        }
    }
}
