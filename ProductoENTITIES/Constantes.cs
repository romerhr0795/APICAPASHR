namespace ProductoENTITIES
{
    public class Constantes
    {
        public static class conexion
        {
            public const string Mece = "Data Source=10.10.72.161\\SQL2016_1;Initial Catalog=APIHR;Integrated Security=True;";
        }

        public static class Procedimientos
        {
            public const string ObtenerProductos = "sp_lista_productos";
            public const string ObtenerLista = "ObtenerProductoPorId";
            public const string EditarProducto = "Editar_producto";
            public const string CrearProduct = "sp_guardar_producto";
            public const string Eliminar = "Eliminar_Producto";

        }
    }
}