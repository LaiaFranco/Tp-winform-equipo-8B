using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string CódigoDeArtculo { get; set;  }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public Marca Marca { get; set;  } //(seleccionable de una lista desplegable).
        public Categoria Categoria{ get; set; }   //(seleccionable de una lista desplegable.
        public Imagen Imagen { get; set; }
        public decimal Precio { get; set;  }
    }
}
