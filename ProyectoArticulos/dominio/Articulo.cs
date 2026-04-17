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
        public string CódigoDeArtculo { get; set;  }
        public string Nombre { get; set; }
        public string Descripción { get; set; } 
        public Marca Marca { get; set;  } //(seleccionable de una lista desplegable).
        public Categoria Categoría{ get; set; }   //(seleccionable de una lista desplegable.
        public Imagen imagen { get; set; }
        public decimal Precio { get; set;  }
    }
}
