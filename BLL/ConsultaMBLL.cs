using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class ConsultaMBLL
    {



        public static bool Guardar(ConsultasM consultas)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();
            try
            {
                Repositorio<Materiales> prod = new Repositorio<Materiales>();



                if (db.ConsultasM.Add(consultas) != null)
                {

                    foreach (var item in consultas.Materiales)
                    {
                        var material = prod.Buscar(item.Id);
                        material.Existencia = material.Existencia - item.Cantidad;
                        prod.Modificar(material);

                    }

                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();
            Repositorio<ConsultasM> vent = new Repositorio<ConsultasM>();
            Repositorio<Materiales> prod = new Repositorio<Materiales>();
           

            try
            {
                var consulta = db.ConsultasM.Find(id);
               
               

                foreach (var item in consulta.Materiales)
                {
                    var materiales = prod.Buscar(item.Id);
                    materiales.Existencia = materiales.Existencia + item.Cantidad;
                    prod.Modificar(materiales);

                }


                db.Entry(consulta).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        

        public static bool Modificar(ConsultasM consultas)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();
            Repositorio<ConsultasM> cons = new Repositorio<ConsultasM>();
            Repositorio<Materiales> prod = new Repositorio<Materiales>();
            try
            {
                var consulta = cons.Buscar(consultas.ConsultaId);

                

                if (consultas != null)
                {
                    foreach (var item in consulta.Materiales)
                    {
                        db.Materiales.Find(item.Id).Existencia += item.Cantidad;

                        if (!consultas.Materiales.ToList().Exists(v => v.Id == item.Id))
                        {

                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in consultas.Materiales)
                    {
                        db.Materiales.Find(item.Id).Existencia -= item.Cantidad;
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(consultas).State = EntityState.Modified;
                }


                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        


    }
}
