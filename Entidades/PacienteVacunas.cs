using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PacienteVacunas
    {
        [Key]
        public int Id { get; set; }
        public int PacienteId { get; set; }

        public string Descripcion { get; set; }

        public PacienteVacunas()
        {
            Id = 0;
            PacienteId = 0;
            Descripcion = string.Empty;
        }

        public PacienteVacunas(int id, int pacienteId, string descripcion)
        {
            Id = id;
            PacienteId = pacienteId;
            Descripcion = descripcion;
        }
    }
}
