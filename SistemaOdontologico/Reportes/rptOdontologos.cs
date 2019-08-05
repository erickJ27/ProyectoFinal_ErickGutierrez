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
    public partial class rptOdontologos : Form
    {
        private List<Odontologos> ListaOdontologos;
        public rptOdontologos(List<Odontologos> odontologos)
        {
            this.ListaOdontologos = odontologos;
            InitializeComponent();
        }

        private void RptOdontologos_Load(object sender, EventArgs e)
        {
            ListadoOdontologos listadoOdontologo = new ListadoOdontologos();
            listadoOdontologo.SetDataSource(ListaOdontologos);

            crystalReportViewer1.ReportSource = listadoOdontologo;
            crystalReportViewer1.Refresh();
        }
    }
}
