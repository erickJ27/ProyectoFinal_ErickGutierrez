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
    public partial class rptVacunas : Form
    {
        private List<Vacunas> ListaVacunas;
        public rptVacunas(List<Vacunas> vacunas)
        {
            this.ListaVacunas = vacunas;
            InitializeComponent();
        }

        private void RptVacunas_Load(object sender, EventArgs e)
        {
            ListadoVacunas listadoVacunas = new ListadoVacunas();
            listadoVacunas.SetDataSource(ListaVacunas);

            crystalReportViewer1.ReportSource = listadoVacunas;
            crystalReportViewer1.Refresh();
        }
    }
}
