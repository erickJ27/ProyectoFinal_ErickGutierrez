﻿using BLL;
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
        public cUsuarios()
        {
            InitializeComponent();
        }

        

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            rptUsuarios ver = new rptUsuarios();
            ver.Show();
        }

        private void ConsultarButton_Click_1(object sender, EventArgs e)
        {

            var lista = new List<Usuarios>();
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
                                lista = dbe.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriterioTextBox.Text);
                                lista = dbe.GetList(p => p.UsuarioId == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Email":
                                lista = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;

                            case "Usuario":
                                lista = dbe.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
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

                    UsuariosDataGridView.DataSource = null;
                    UsuariosDataGridView.DataSource = lista;
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
                                lista = dbe.GetList(p => p.UsuarioId == id);
                                break;

                            case "Nombres":
                                lista = dbe.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                                break;


                            case "Email":
                                lista = dbe.GetList(p => p.Email.Contains(CriterioTextBox.Text));

                                break;

                            case "Usuario":
                                lista = dbe.GetList(p => p.Usuario.Contains(CriterioTextBox.Text));
                                break;

                            default:
                                break;
                        }

                    }
                    else
                    {
                        lista = dbe.GetList(p => true);
                    }
                    UsuariosDataGridView.DataSource = null;
                    UsuariosDataGridView.DataSource = lista;
                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");
                }
            }
        }

        private void FiltrarFechaCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UsuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
