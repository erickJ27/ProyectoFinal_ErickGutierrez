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
    public partial class cPacientes : Form
    {
        public List<Pacientes> Lista;
        public cPacientes()
        {
            InitializeComponent();
            FiltroComboBox.Text = "Todo";
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var lista = new List<Pacientes>();
            Repositorio<Pacientes> dbe = new Repositorio<Pacientes>();
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
                                lista = dbe.GetList(p => p.PacienteID == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Sexo":
                                lista = dbe.GetList(p => p.Sexo.Contains(CriterioTextBox.Text));
                                break;

                            case "Grupo Sanguineo":
                                lista = dbe.GetList(p => p.GrupoSanguineo.Contains(CriterioTextBox.Text));
                                break;
                            case "Cedula":
                                lista = dbe.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));

                                break;
                            case "Telefono":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));

                                break;
                            case "Celular":
                                lista = dbe.GetList(p => p.Celular.Contains(CriterioTextBox.Text));

                                break;
                            case "Seguro Medico":
                                lista = dbe.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));

                                break;
                            case "Direccion":
                                lista = dbe.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));

                                break;
                            case "Email":
                                lista = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;
                            default:
                                break;
                        }
                        lista = lista.Where(c => c.FechaIngreso.Date >= DesdeDateTimePicker.Value.Date && c.FechaIngreso.Date <= HastaDateTimePicker.Value.Date).ToList();
                    }
                    else
                    {

                        lista = dbe.GetList(p => true);
                        lista = lista.Where(c => c.FechaIngreso.Date >= DesdeDateTimePicker.Value.Date && c.FechaIngreso.Date <= HastaDateTimePicker.Value.Date).ToList();
                    }

                    Lista = lista;
                    PacientesDataGridView.DataSource = Lista;
                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");
                }
            }
            else
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
                                lista = dbe.GetList(p => p.PacienteID == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Sexo":
                                lista = dbe.GetList(p => p.Sexo.Contains(CriterioTextBox.Text));
                                break;

                            

                            case "Grupo Sanguineo":
                                lista = dbe.GetList(p => p.GrupoSanguineo.Contains(CriterioTextBox.Text));
                                break;
                            case "Cedula":
                                lista = dbe.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));

                                break;
                            case "Telefono":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));

                                break;
                            case "Celular":
                                lista = dbe.GetList(p => p.Celular.Contains(CriterioTextBox.Text));

                                break;
                            case "Seguro Medico":
                                lista = dbe.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));

                                break;
                            case "Direccion":
                                lista = dbe.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));

                                break;
                            case "Email":
                                lista = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        lista = dbe.GetList(p => true);
                    }
                    Lista = lista;
                    PacientesDataGridView.DataSource = Lista;

            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (PacientesDataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                rptPacientes p = new rptPacientes(Lista);
                p.ShowDialog();
            }
        }
    }
}
