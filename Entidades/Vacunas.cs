using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vacunas
    {
        [Key]
        public int VacunasId { get; set; }
        public string Descripcion { get; set; }

        public Vacunas()
        {
            VacunasId = 0;
            Descripcion = string.Empty;
        }
    }
}
