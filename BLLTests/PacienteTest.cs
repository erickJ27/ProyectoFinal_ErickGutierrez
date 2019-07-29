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
    public class PacienteTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
             Pacientes p= new Pacientes();
            p.PacienteID = 1;
            p.Nombres = "erick";
            p.Sexo = 'M';
            p.FechaNacimiento = DateTime.Now;
            p.GrupoSanguineo = "A";
            p.Cedula = "4535";
            p.Telefono = "53453";
            p.Celular = "4354";
            p.SeguroMedico = "asd";
            p.Direccion = "micasa";
            p.Email = "efs#";
            p.ObservacionPacientes = "e345";
            p.FechaNacimiento = DateTime.Now;


            Repositorio<Pacientes> repositorio = new Repositorio<Pacientes>();
            bool paso = false;
            paso = repositorio.Guardar(p);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Pacientes> repositorio = new Repositorio<Pacientes>();
            bool paso = false;
            Pacientes p = repositorio.Buscar(1);
            p.Nombres = "Usuario";
            paso = repositorio.Modificar(p);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Pacientes> repositorio = new Repositorio<Pacientes>();
            Pacientes p = repositorio.Buscar(1);
            Assert.IsNotNull(p);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Pacientes> repositorio = new Repositorio<Pacientes>();
            List<Pacientes> lista = new List<Pacientes>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void EliminarTest()
        {
           Repositorio<Pacientes> repositorio = new Repositorio<Pacientes>();
            bool paso = false;
            paso = repositorio.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
