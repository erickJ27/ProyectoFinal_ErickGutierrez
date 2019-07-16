using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace DAL
{
    public class CentroOdontologicoContexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public CentroOdontologicoContexto() : base("ConStr")
        {

        }

    }
}
