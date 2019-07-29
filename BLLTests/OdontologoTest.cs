using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BLL;

namespace BLLTests
{
    [TestClass()]
    public class OdontologoTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
             Odontologos o= new Odontologos();


            o.OdontologoId = 1;
            o.Nombres = "rgrg";
            o.Cedula = "3453";
            o.Telefono = "453";
            o.Celular = "46564";
            o.Especialidad = "eee";
            o.Direccion = "rte";
            o.Email = "rtet";
            o.FechaIngreso = DateTime.Now;


        Repositorio<Odontologos> repositorio = new Repositorio<Odontologos>();
            bool paso = false;
            paso = repositorio.Guardar(o);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Odontologos> repositorio = new Repositorio<Odontologos>();
            bool paso = false;
            Odontologos o = repositorio.Buscar(1);
            o.Nombres = "Usuario";
            paso = repositorio.Modificar(o);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Odontologos> repositorio = new Repositorio<Odontologos>();
            Odontologos p = repositorio.Buscar(1);
            Assert.IsNotNull(p);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Odontologos> repositorio = new Repositorio<Odontologos>();
            List<Odontologos> lista = new List<Odontologos>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void EliminarTest()
        {
           Repositorio<Odontologos> repositorio = new Repositorio<Odontologos>();
            bool paso = false;
            paso = repositorio.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
