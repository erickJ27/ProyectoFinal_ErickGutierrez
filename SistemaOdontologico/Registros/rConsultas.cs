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
using SistemaOdontologico.Reportes;


namespace SistemaOdontologico.Registros
{
    public partial class rConsultas : Form
    {
        public List<MaterialesDetalle> Detalle { get; set; }
        public rConsultas()
        {
            InitializeComponent();
            this.Detalle = new List<MaterialesDetalle>();
            ListadoPacientes();
            ListadoOdontologos();
            ListadoMateriales();

            PacienteComboBox.Text = null;
            OdontologoComboBox.Text = null;
            MaterialesComboBox.Text = null;

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
            c.SubTotal =Convert.ToDecimal(SubTotalTextBox.Text) ;
            c.Itbis = Convert.ToDecimal(ItibisTextBox.Text);
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
            PacienteComboBox.SelectedValue = c.PacienteId;
            OdontologoComboBox.SelectedValue = c.OdontologoId;
            FechaActualDateTimePicker.Value = c.FechaActual;
            FechaConsultaProximaDateTimePicker.Value = c.FechaConsultaProxima;
            
            SubTotalTextBox.Text= Convert.ToString(c.SubTotal);
            ItibisTextBox.Text =Convert.ToString(c.Itbis);
            TotalTextBox.Text =Convert.ToString(c.Total);
            DiagnosticoTextBox.Text = c.Diagnostico;
            ObservacionTextBox.Text = c.Observacion;
            TratamientoTextBox.Text = c.Tratamiento;
            this.Detalle = c.Materiales;
            CargarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(PacienteComboBox.Text))
            {
                MyErrorProvider.SetError(PacienteComboBox, "El campo Paciente no puede estar vacio");
                PacienteComboBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(OdontologoComboBox.Text))
            {
                MyErrorProvider.SetError(OdontologoComboBox, "El campo Odontologo no puede estar vacio");
                OdontologoComboBox.Focus();
                paso = false;
            }
            if (FechaConsultaProximaDateTimePicker.Value < FechaActualDateTimePicker.Value)
            {
                MyErrorProvider.SetError(FechaConsultaProximaDateTimePicker, "El campo FechaConsultaProxima no puede tener una fecha anterior a fecha actual");
                FechaConsultaProximaDateTimePicker.Focus();
                paso = false;
            }
            if (SubTotalTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(SubTotalTextBox, "El Subtotal no puede estar vacio");
                SubTotalTextBox.Focus();
                paso = false;
            }
            if (ItibisTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(ItibisTextBox, "El Itbis no puede estar vacio");
                ItibisTextBox.Focus();
                paso = false;
            }
            if (TotalTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(TotalTextBox, "El Total no puede estar vacio");
                TotalTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DiagnosticoTextBox.Text))
            {
                MyErrorProvider.SetError(DiagnosticoTextBox, "El Diagnostico no puede estar vacio");
                TotalTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ObservacionTextBox.Text))
            {
                MyErrorProvider.SetError(ObservacionTextBox, "La Observacion no puede estar vacio");
                ObservacionTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TratamientoTextBox.Text))
            {
                MyErrorProvider.SetError(TratamientoTextBox, "El Tratamiento no puede estar vacio");
                TratamientoTextBox.Focus();
                paso = false;
            }
            if (FechaActualDateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechaActualDateTimePicker, "No se puede registrar esta fecha.");
                FechaActualDateTimePicker.Focus();
                paso = false;
            }
            if(FechaConsultaProximaDateTimePicker.Value > FechaActualDateTimePicker.Value)
            {
                MyErrorProvider.SetError(FechaConsultaProximaDateTimePicker, "La proxima Consulta no puede ser el mismo dia.");
                FechaConsultaProximaDateTimePicker.Focus();
                paso = false;
            }
            return paso;
        }
        private void ListadoPacientes()
        {
            Repositorio<Pacientes> db = new Repositorio<Pacientes>(new DAL.CentroOdontologicoContexto());
            var lista = new List<Pacientes>();
            lista = db.GetList(l => true);
            PacienteComboBox.DataSource = lista;
            PacienteComboBox.DisplayMember = "Nombres";
            PacienteComboBox.ValueMember = "PacienteID";
        }
        private void ListadoOdontologos()
        {
            Repositorio<Odontologos> db = new Repositorio<Odontologos>(new DAL.CentroOdontologicoContexto());
            var lista = new List<Odontologos>();
            lista = db.GetList(l => true);
            OdontologoComboBox.DataSource = lista;
            OdontologoComboBox.DisplayMember = "Nombres";
            OdontologoComboBox.ValueMember = "OdontologoId";
        }
        private void ListadoMateriales()
        {
            Repositorio<Materiales> db = new Repositorio<Materiales>(new DAL.CentroOdontologicoContexto());
            var lista = new List<Materiales>();
            lista = db.GetList(l => true);
            MaterialesComboBox.DataSource = lista;
            MaterialesComboBox.DisplayMember = "Descripcion";
            MaterialesComboBox.ValueMember = "MaterialId";
        }

   
        private void LlenarPrecio()
        {
            Repositorio<Materiales> repositorio = new Repositorio<Materiales>();
            List<Materiales> lista = repositorio.GetList(c => c.Descripcion == MaterialesComboBox.Text);
            foreach (var item in lista)
            {
                PrecioTextBox.Text = Convert.ToString(item.CostoUnidad);
            }
        }
       
        public void CalcularItbis()
        {
            decimal itbis = 0;
            foreach (var item in Detalle)
            {
                itbis += item.Itbis;
            }
            ItibisTextBox.Text = itbis.ToString();
         }
        public void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Detalle)
            {
                total += (item.Importe) + item.Itbis;
            }
           TotalTextBox.Text = total.ToString();
        }

        public void CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in Detalle)
            {
                subtotal += item.Importe;
            }
            SubTotalTextBox.Text = subtotal.ToString();
        }
        
        public string id_mat;
        private bool ExisteEnGrid()
        {

            bool paso = true;

            if(MaterialesDataGridView.RowCount > 0)
            {
                id_mat = MaterialesComboBox.SelectedValue.ToString();
                for (int i = 0; i < MaterialesDataGridView.RowCount; i++)
                {
                    if (Convert.ToInt16(MaterialesDataGridView.Rows[i].Cells["Id"].Value) == Convert.ToInt16(id_mat))
                    {
                        MessageBox.Show("El material ya ha sido ingresado");
                        paso = false;

                    }
                }

            }

            return paso;

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            ConsultasM c = new ConsultasM();
            if (!Validar())
                return;

            c = LLenarClase();
            if (IdNumericUpDown.Value == 0)
            {
                paso = ConsultaMBLL.Guardar(c);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una consulta que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ConsultaMBLL.Modificar(c);
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
            Repositorio<ConsultasM> db = new Repositorio<ConsultasM>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar una consulta que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (db.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar una consulta que no existe");
        }


        private void NuevoPacienteButton_Click(object sender, EventArgs e)
        {
            rPacientes p = new rPacientes();
            
            p.ShowDialog();
            ListadoPacientes();
        }

        private void NuevoOdontologoButton_Click(object sender, EventArgs e)
        {
            rOdontologos o = new rOdontologos();
            
            o.ShowDialog();
            ListadoOdontologos();
        }

        private void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            List<MaterialesDetalle> detalles = new List<MaterialesDetalle>();
            Repositorio<ConsultasM> db = new Repositorio<ConsultasM>(new DAL.CentroOdontologicoContexto());
            if (MaterialesComboBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(MaterialesComboBox, "No a seleccionado un material");
                MaterialesComboBox.Focus();
                return;
            }

            if (CantidadNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "Cantidad invalidad");
                CantidadNumericUpDown.Focus();
                return;
            }
            if (MaterialesDataGridView.DataSource != null)
                this.Detalle = (List<MaterialesDetalle>)MaterialesDataGridView.DataSource;
            
            if (ExisteEnGrid() == false)
            {
                MyErrorProvider.SetError(MaterialesComboBox, "El Material ya existe en el Grid");
                MaterialesComboBox.Focus();

                return;
            }

            this.Detalle.Add(new MaterialesDetalle()
            {
                Id = (int)MaterialesComboBox.SelectedValue,
                ConsultaId = (int)IdNumericUpDown.Value,
                Descripcion = MaterialesComboBox.Text,
                Cantidad = (int)CantidadNumericUpDown.Value,
                Importe = Convert.ToDecimal(PrecioTextBox.Text) * CantidadNumericUpDown.Value,
                Itbis= (Convert.ToDecimal(PrecioTextBox.Text) * CantidadNumericUpDown.Value)*0.18m,
            });

            CargarGrid();
            
            CalcularSubtotal();
            CalcularItbis();
            CalcularTotal();
            MaterialesComboBox.Text = null;
            PrecioTextBox.Text = null;
            CantidadNumericUpDown.Value = 0;

        }

        

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            ConsultasM c = new ConsultasM();
            Repositorio<ConsultasM> db = new Repositorio<ConsultasM>();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            c = db.Buscar(id);

            if (c != null)
            {
                LLenarCampo(c);
            }
            else
                MessageBox.Show("Consulta no encontrada");
        }

        private void AgregarMaterialesButton_Click(object sender, EventArgs e)
        {
            rMateriales m = new rMateriales();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.ShowDialog();
            ListadoMateriales();
        }

        private void MaterialesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            LlenarPrecio();
           

        }

        private void EliminarMaterialButton_Click(object sender, EventArgs e)
        {
            if (MaterialesDataGridView.Rows.Count > 0 && MaterialesDataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(MaterialesDataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
        }
    }
}
