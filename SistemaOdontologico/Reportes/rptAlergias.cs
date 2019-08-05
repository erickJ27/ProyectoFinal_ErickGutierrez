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
    public partial class rptAlergias : Form
    {
        private List<Alergias> ListaAlergias;
        public rptAlergias(List<Alergias> alergias)
        {
            this.ListaAlergias = alergias;
            InitializeComponent();
        }

        private void RptAlergias_Load(object sender, EventArgs e)
        {
            ListadoAlergias listadoAlergias = new ListadoAlergias();
            listadoAlergias.SetDataSource(ListaAlergias);

            crystalReportViewer1.ReportSource = listadoAlergias;
            crystalReportViewer1.Refresh();
        }
    }
}
