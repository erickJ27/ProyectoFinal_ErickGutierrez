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
using SistemaOdontologico.Reportes;

namespace SistemaOdontologico.Consultas
{
    public partial class cOdontologos : Form
    {
        public List<Odontologos> Lista;
        public cOdontologos()
        {
            
            InitializeComponent();
            FiltroComboBox.Text = "Todo";
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {

            var lista = new List<Odontologos>();
            Repositorio<Odontologos> dbe = new Repositorio<Odontologos>();
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
                                lista = dbe.GetList(p => p.OdontologoId == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
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
                            case "Especialidad":
                                lista = dbe.GetList(p => p.Especialidad.Contains(CriterioTextBox.Text));
                                break;
                            case "Direccion":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                                break;
                            case "Email":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
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
                    OdontologosDataGridView.DataSource = Lista;
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
                                lista = dbe.GetList(p => p.OdontologoId == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
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
                            case "Especialidad":
                                lista = dbe.GetList(p => p.Especialidad.Contains(CriterioTextBox.Text));
                                break;
                            case "Direccion":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                                break;
                            case "Email":
                                lista = dbe.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
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
                    OdontologosDataGridView.DataSource = Lista;

            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (OdontologosDataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                rptOdontologos o = new rptOdontologos(Lista);
                o.ShowDialog();
            }
        }
    }
}
