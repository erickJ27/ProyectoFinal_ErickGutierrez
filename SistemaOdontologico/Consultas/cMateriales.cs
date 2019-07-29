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
namespace SistemaOdontologico.Consultas
{
    public partial class cMateriales : Form
    {
        public cMateriales()
        {
            InitializeComponent();
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
                EspecialidadesDataGridView.DataSource = null;
                EspecialidadesDataGridView.DataSource = lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Introdujo un dato incorrecto");
            }
        }
    }
}
