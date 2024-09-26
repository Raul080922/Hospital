using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Consulta
    {

        public int IdConsulta { get; set; }
        public int IdDoctor { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaConsulta { get; set; }

    }
}
