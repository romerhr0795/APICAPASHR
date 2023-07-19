using System.Data;
using System.Data.SqlClient;
using ProductoENTITIES;
using ProductosDAL;

namespace ProductosBL
{
    public class ProductosBL
    {
        public List<Producto> Lista()
        {
            return new List<Producto>();
        }
        public Producto Obtener_Producto(int idProducto)
        {
            return new Producto();
        }
        public Producto Guardar_producto(Producto objecto)
        {
            return objecto;
        }
        public Producto Editar(Producto objecto)
        {
            return objecto;
        }
        public bool Eliminar(int idProducto)
        {
            return false;
        }
    }
}