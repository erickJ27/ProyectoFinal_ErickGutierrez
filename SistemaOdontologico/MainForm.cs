using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaOdontologico.Registros;
using SistemaOdontologico.Consultas;
using SistemaOdontologico.Reportes;
namespace SistemaOdontologico
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        

        private void ConsultaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cConsultas ver = new cConsultas();
            ver.Show();
        }

        private void ReportesDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptUsuarios ver = new rptUsuarios();
            ver.Show();
        }

        private void RegistroDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios ver = new rUsuarios();
            ver.Show();
        }
    }
}
