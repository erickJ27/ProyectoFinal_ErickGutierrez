using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alergias
    {
        [Key]
        public int AlergiasId { get; set; }
        public string Descripcion { get; set; }

        public Alergias()
        {
            AlergiasId = 0;
            Descripcion = string.Empty;
        }
    }
}
