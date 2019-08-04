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
using SistemaOdontologico.Reportes;
namespace SistemaOdontologico.Consultas
{
    public partial class cConsultasMedicas : Form
    {
        public cConsultasMedicas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var lista = new List<ConsultasM>();
            Repositorio<ConsultasM> dbe = new Repositorio<ConsultasM>();
            if (FiltrarFechaCheckBox.Checked == true)
            {
                
                try
                {
                    if (CriterioTextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltroComboBox.Text)
                        {
                            case "Todo":
                                lista = dbe.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriterioTextBox.Text);
                                lista = dbe.GetList(p => p.ConsultaId == id);
                                break;

                            case "Paciente":
                                lista = dbe.GetList(p => Convert.ToString(p.PacienteId).Contains(CriterioTextBox.Text));
                                break;


                            case "Odontologo":
                                lista = dbe.GetList(p => Convert.ToString(p.OdontologoId).Contains(CriterioTextBox.Text));

                                break;

                            case "SubTotal":
                                lista = dbe.GetList(p => Convert.ToString(p.SubTotal).Contains(CriterioTextBox.Text));

                                break;
                            case "Itbis":
                                lista = dbe.GetList(p =>Convert.ToString(p.Itbis).Contains(CriterioTextBox.Text));
                                break;
                            case "Total":
                                lista = dbe.GetList(p => Convert.ToString(p.Total).Contains(CriterioTextBox.Text));

                                break;
                            
                            default:
                                break;
                        }
                        if(TipoFechaComboBox.Text== "Fecha actual")
                        {
                            lista = lista.Where(c => c.FechaActual.Date >= DesdeDateTimePicker.Value.Date && c.FechaActual.Date <= HastaDateTimePicker.Value.Date).ToList();
                        }else
                            lista = lista.Where(c => c.FechaConsultaProxima.Date >= DesdeDateTimePicker.Value.Date && c.FechaConsultaProxima.Date <= HastaDateTimePicker.Value.Date).ToList();

                    }
                    else
                    {

                        lista = dbe.GetList(p => true);
                        lista = lista.Where(c => c.FechaActual.Date >= DesdeDateTimePicker.Value.Date && c.FechaActual.Date <= HastaDateTimePicker.Value.Date).ToList();
                    }

                    ConsultaMedicaDataGridView.DataSource = null;
                    ConsultaMedicaDataGridView.DataSource = lista;
                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");
                }
            }
            else
            {
                try
                {
                    if (CriterioTextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltroComboBox.Text)
                        {
                            case "Todo":
                                lista = dbe.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriterioTextBox.Text);
                                lista = dbe.GetList(p => p.ConsultaId == id);
                                break;

                            case "Paciente":
                                lista = dbe.GetList(p => Convert.ToString(p.PacienteId).Contains(CriterioTextBox.Text));
                                break;


                            case "Odontologo":
                                lista = dbe.GetList(p => Convert.ToString(p.OdontologoId).Contains(CriterioTextBox.Text));

                                break;

                            case "SubTotal":
                                lista = dbe.GetList(p => Convert.ToString(p.SubTotal).Contains(CriterioTextBox.Text));

                                break;
                            case "Itbis":
                                lista = dbe.GetList(p => Convert.ToString(p.Itbis).Contains(CriterioTextBox.Text));
                                break;
                            case "Total":
                                lista = dbe.GetList(p => Convert.ToString(p.Total).Contains(CriterioTextBox.Text));

                                break;

                            default:
                                break;
                        }

                    }
                    else
                    {
                        lista = dbe.GetList(p => true);
                    }
                    ConsultaMedicaDataGridView.DataSource = null;
                    ConsultaMedicaDataGridView.DataSource = lista;
                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");
                }
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            rptConsultaMedica ver = new rptConsultaMedica();
            ver.Show();
        }
    }
}
