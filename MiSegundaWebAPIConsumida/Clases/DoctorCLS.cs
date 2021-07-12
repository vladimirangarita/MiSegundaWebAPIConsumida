using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSegundaWebAPIConsumida.Clases
{
   public class DoctorCLS
    {

        public int IiDoctor { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreClinica { get; set; }
        public string Email { get; set; }
        public string NombreEspecialidad { get; set; }
        public DateTime FechaContrato { get; set; }

        //Agregar o Editar
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Foto { get; set; }
        public string NombreArchivo { get; set; }
        public int IidClinica { get; set; }
        public int IidEspecialidad { get; set; }

        public int IidSexo { get; set; }

        public decimal Sueldo { get; set; }
        public string TelefonoCelular { get; set; }
    }
}
