using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pacientes
    {
        [Key]
        public int PacienteID { get; set; }
        public string Nombres { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string SeguroMedico { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string ObservacionPacientes { get; set; }
        public string AntecedentesMedicos { get; set; }
        public string AntecedentesMedicosFamiliares { get; set; }
        public string Alergias { get; set; }
        public string Vacunas { get; set; }


        public Pacientes()
        {
            PacienteID = 0;
            Nombres = string.Empty;
            Sexo=' ';
            FechaNacimiento = DateTime.Now;
            GrupoSanguineo= string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            SeguroMedico = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            ObservacionPacientes = string.Empty;
            AntecedentesMedicos = string.Empty;
            AntecedentesMedicosFamiliares = string.Empty;
            Alergias = string.Empty;
            Vacunas = string.Empty;
        }

    }
}
