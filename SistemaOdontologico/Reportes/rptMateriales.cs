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
    public partial class rptMateriales : Form
    {
        private List<Materiales> ListaMateriales;
        public rptMateriales(List<Materiales> materiales)
        {
            this.ListaMateriales = materiales;
            InitializeComponent();
        }

        private void RptMateriales_Load(object sender, EventArgs e)
        {
            ListadoMateriales listadoMateriales = new ListadoMateriales();
            listadoMateriales.SetDataSource(ListaMateriales);

            crystalReportViewer1.ReportSource = listadoMateriales;
            crystalReportViewer1.Refresh();
        }
    }
    
}
