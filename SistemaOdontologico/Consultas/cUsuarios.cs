using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaOdontologico.Reportes;

namespace SistemaOdontologico.Consultas
{
    public partial class cUsuarios : Form
    {
        public List<Usuarios> Lista;
        public cUsuarios()
        {
            InitializeComponent();
            FiltroComboBox.Text = "Todo";
        }

        

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                rptUsuarios u = new rptUsuarios(Lista);
                u.ShowDialog();
            }
        }

        private void ConsultarButton_Click_1(object sender, EventArgs e)
        {

            var listado = new List<Usuarios>();
            
        Repositorio<Usuarios> dbe = new Repositorio<Usuarios>();
            if (FiltrarFechaCheckBox.Checked == true)
            {
                try
                {
                    if (CriterioTextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltroComboBox.Text)
                        {
                            case "Todo":
                                listado = dbe.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriterioTextBox.Text);
                                listado = dbe.GetList(p => p.UsuarioId == id);
                                break;

                            case "Nombres":
                                listado = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Email":
                                listado = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;

                            case "Usuario":
                                listado = dbe.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
                                break;

                            default:
                                break;
                        }
                        listado = listado.Where(c => c.FechaIngreso.Date >= DesdeDateTimePicker.Value.Date && c.FechaIngreso.Date <= HastaDateTimePicker.Value.Date).ToList();
                    }
                    else
                    {

                        listado = dbe.GetList(p => true);
                        listado = listado.Where(c => c.FechaIngreso.Date >= DesdeDateTimePicker.Value.Date && c.FechaIngreso.Date <= HastaDateTimePicker.Value.Date).ToList();
                    }

                    Lista = listado;
                    UsuariosDataGridView.DataSource = Lista;
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
                                listado = dbe.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriterioTextBox.Text);
                                listado = dbe.GetList(p => p.UsuarioId == id);
                                break;

                            case "Nombres":
                                listado = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Email":
                                listado = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;

                            case "Usuario":
                                listado = dbe.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
                                break;

                            default:
                                break;
                        }

                    }
                    else
                    {
                        listado = dbe.GetList(p => true);
                    }
                    
                
                Lista = listado;
                UsuariosDataGridView.DataSource = Lista;
            }
        }

        
    }
}
