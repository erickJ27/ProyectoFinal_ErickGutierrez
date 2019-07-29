using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MaterialesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Itbis { get; set; }

        
        public MaterialesDetalle()
        {
            Id = 0;
            ConsultaId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Importe = 0;
            Itbis = 0;
        }


    }
}
