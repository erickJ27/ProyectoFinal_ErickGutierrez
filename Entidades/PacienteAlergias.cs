using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PacienteAlergias
    {
        [Key]
        public int Id { get; set; }
        public int PacienteId { get; set; }

        public string Descripcion { get; set; }

        public PacienteAlergias()
        {
            Id = 0;
            PacienteId = 0;
            Descripcion = string.Empty;
        }
        public PacienteAlergias(int id,int pacienteId,string descripcion)
        {
            Id = id;
            PacienteId = pacienteId;
            Descripcion = descripcion;
        }


    }
}
