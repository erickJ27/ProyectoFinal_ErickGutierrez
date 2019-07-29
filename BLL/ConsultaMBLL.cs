using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace BLL
{
    public class ConsultaMBLL
    {
/*
        public static bool Guardar(ConsultasM c)
        {
            bool paso = false;
            CentroOdontologicoContexto db = new CentroOdontologicoContexto();
            try
            {
                Repositorio<Materiales> dbEst = new Repositorio<Materiales>(new DAL.CentroOdontologicoContexto());

                if (db.ConsultasM.Add(c) != null)
                {
                    Materiales material = new Materiales();
                    var materiales = dbEst.Buscar(material.MaterialId);

                    //c.CalcularMonto();
                    //c.Balance += c.Monto;
                    //paso = db.SaveChanges() > 0;
                    //dbEst.Modificar(estudiantes);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public static bool Modificar(Inscripciones entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Repositorio<Estudiantes> dbE = new Repositorio<Estudiantes>();


            try
            {


                var anterior = new Repositorio<Inscripciones>().Buscar(entity.InscripcionId);
                var estudiantes = dbE.Buscar(entity.EstudianteId);

                estudiantes.Balance -= anterior.Monto;

                foreach (var item in anterior.Asignaturas)
                {
                    if (!entity.Asignaturas.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }

                }

                foreach (var item in entity.Asignaturas)
                {
                    if (item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }

                    else
                        db.Entry(item).State = EntityState.Modified;
                }


                entity.CalcularMonto();
                estudiantes.Balance += entity.Monto;
                dbE.Modificar(estudiantes);

                db.Entry(entity).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public static Estudiantes Buscar(int id)
        {
            Estudiantes estudiantes = new Estudiantes();
            Contexto db = new Contexto();


            try
            {
                estudiantes = db.Estudiantes.Find(id);



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return estudiantes;

        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Repositorio<Estudiantes> dbEst = new Repositorio<Estudiantes>(new DAL.Contexto());
            try
            {
                var Inscripcion = db.Inscripciones.Find(id);
                var estudiante = dbEst.Buscar(Inscripcion.EstudianteId);
                estudiante.Balance = estudiante.Balance - Inscripcion.Monto;
                dbEst.Modificar(estudiante);
                db.Entry(Inscripcion).State = EntityState.Deleted;
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
        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripcion)
        {
            List<Inscripciones> Lista = new List<Inscripciones>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Inscripciones.Where(inscripcion).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }*/
    }
}
