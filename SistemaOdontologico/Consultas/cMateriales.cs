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
    public partial class cMateriales : Form
    {
        public List<Materiales> Lista;
        public cMateriales()
        {
            InitializeComponent();
            FiltroComboBox.Text = "Todo";
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var lista = new List<Materiales>();
            Repositorio<Materiales> dbe = new Repositorio<Materiales>();
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
                            lista = dbe.GetList(p => p.MaterialId == id);
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
                MaterialesDataGridView.DataSource = Lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Introdujo un dato incorrecto");
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (MaterialesDataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                rptMateriales m = new rptMateriales(Lista);
                m.ShowDialog();
            }
        }
    }
}
