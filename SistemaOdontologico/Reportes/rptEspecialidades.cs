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
    public partial class rptEspecialidades : Form
    {
        private List<Especialidades> ListaEspecialidades;
        public rptEspecialidades(List<Especialidades> especialidades)
        {
            this.ListaEspecialidades = especialidades;
            InitializeComponent();
        }

        private void RptEspecialidades_Load(object sender, EventArgs e)
        {
            ListadoEspecialidades listadoEspecialidades = new ListadoEspecialidades();
            listadoEspecialidades.SetDataSource(ListaEspecialidades);

            crystalReportViewer1.ReportSource = listadoEspecialidades;
            crystalReportViewer1.Refresh();
        }
    }
}
