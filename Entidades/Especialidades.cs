using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidades
    {
        [Key]
        public int EspecialidadId { get; set; }
        public string Descripcion { get; set; }

        public Especialidades()
        {
            EspecialidadId = 0;
            Descripcion = string.Empty;
        }


    }
}
