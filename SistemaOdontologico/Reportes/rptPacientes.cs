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

namespace SistemaOdontologico.Reportes
{
    public partial class rptPacientes : Form
    {
        private List<Pacientes> ListaPacientes;
        public rptPacientes(List<Pacientes> pacientes)
        {
            this.ListaPacientes = pacientes;
            InitializeComponent();
        }

        private void RptPacientes_Load(object sender, EventArgs e)
        {
            ListadoPacientes listadoPacientes = new ListadoPacientes();
            listadoPacientes.SetDataSource(ListaPacientes);

            crystalReportViewer1.ReportSource = listadoPacientes;
            crystalReportViewer1.Refresh();
        }
    }
}
