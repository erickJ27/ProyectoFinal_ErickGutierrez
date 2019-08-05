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
    public partial class cAlergias : Form
    {
        public List<Alergias> Lista;
        public cAlergias()
        {
            InitializeComponent();
            FiltroComboBox.Text = "Todo";
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var lista = new List<Alergias>();
            Repositorio<Alergias> dbe = new Repositorio<Alergias>();
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
                            lista = dbe.GetList(p => p.AlergiasId == id);
                            break;

                        case "Descripcion":
                            lista = dbe.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
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
                AlergiasDataGridView.DataSource = Lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Introdujo un dato incorrecto");
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (AlergiasDataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                rptAlergias a  = new rptAlergias(Lista);
                a.ShowDialog();
            }
        }
    }
}
