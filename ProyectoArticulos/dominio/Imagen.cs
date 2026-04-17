using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int idImagen { get; }
        public int idArticulo { get; set; }
        public string urlImagen { get; set; }
    }
}
