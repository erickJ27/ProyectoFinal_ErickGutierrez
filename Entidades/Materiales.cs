using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materiales
    {
        [Key]
        public int MaterialId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal CostoUnidad { get; set; } 

        public Materiales()
        {
            MaterialId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            CostoUnidad = 0;


        }
    }
}
