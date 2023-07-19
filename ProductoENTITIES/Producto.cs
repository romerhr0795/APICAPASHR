using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoENTITIES
{
    public class Producto
    {

        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string categoria { get; set; }
        public decimal Precio { get; set; }

    }
}
}
