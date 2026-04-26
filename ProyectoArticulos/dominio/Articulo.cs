using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Cod.Articulo")]
        public string CodigoDeArtculo{ get; set;  }
        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Marca")]
        public Marca Marca { get; set;  } //(seleccionable de una lista desplegable).
        
        [DisplayName("Categoria")]
        public Categoria Categoria{ get; set; }   //(seleccionable de una lista desplegable.
        public  Imagen Imagen { get; set; }
        
        [DisplayName("Precio")]
        public decimal Precio { get; set; }
    }
}
