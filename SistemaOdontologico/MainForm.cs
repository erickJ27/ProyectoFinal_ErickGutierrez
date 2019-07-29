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
            cUsuarios ver = new cUsuarios();
            //ver.MdiParent = this;
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void ReportesDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptUsuarios ver = new rptUsuarios();
            //ver.MdiParent = this;
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios ver = new rUsuarios();
            //ver.MdiParent = this;
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rPacientes ver = new rPacientes();
            //ver.MdiParent = this;
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeOdontologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rOdontologos ver = new rOdontologos();
            //ver.MdiParent = this;
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rConsultas ver = new rConsultas();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void ConsultaDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPacientes ver = new cPacientes();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEspecialidades ver = new rEspecialidades();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rMateriales ver = new rMateriales();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void ConsultaDeOdontologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOdontologos ver = new cOdontologos();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void ConsultaDeConsultasMedicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cConsultasMedicas ver = new cConsultasMedicas();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();

        }

        private void ConsultaDeEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEspecialidades ver = new cEspecialidades();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void ConsultaDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cMateriales ver = new cMateriales();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }

        private void RegistroDeVacunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVacunas ver = new rVacunas();
            ver.StartPosition = FormStartPosition.CenterScreen;
            ver.Show();
        }
    }
}
