using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public byte Edad {  get; set; }
        public DateTime FechaNacimiento { get; set;}
        public string Email { get; set; }
        public string Sexo { get; set; }

        //public List<ML.Usuario> usuarios { get; set; }
    }
}
