using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConsultasM
    {
        [Key]
        public int ConsultaId { get; set; }
        public int PacienteId { get; set; }
        public int OdontologoId { get; set; }
        public DateTime FechaActual { get; set; }
        public DateTime FechaConsultaProxima { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observacion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }

        public virtual List<MaterialesDetalle> Materiales { get; set; }

        public ConsultasM()
        {
            ConsultaId = 0;
            PacienteId = 0;
            OdontologoId = 0;
            FechaActual = DateTime.Now;
            FechaConsultaProxima = DateTime.Now;
            Diagnostico = string.Empty;
            Tratamiento = string.Empty;
            Observacion = string.Empty;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
            Materiales = new List<MaterialesDetalle>();
        }



    }
}
