using ProductoENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductosBL
{
public interface Iproducto
    {
        List<Producto> Lista();
        Producto Obtener_Producto(int idProducto);
        Producto Guardar_producto(Producto objecto);
        Producto Editar(Producto objecto);
        bool Eliminar(int idProducto);

    }
}
