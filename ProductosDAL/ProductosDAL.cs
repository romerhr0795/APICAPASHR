using ProductoENTITIES;
using System.Data;
using System.Data.SqlClient;


namespace ProductosDAL
{
    public class ProductosDAL
    {
        public List<Producto> Lista()
        {
            string conexion = Constantes.conexion.Mece;

            List<Producto> lista = new List<Producto>();
            SqlConnection con = new SqlConnection(Constantes.conexion.Mece);

            try
            {

                con.Open();
                var cmd = new SqlCommand(Constantes.Procedimientos.ObtenerProductos, con);
                cmd.CommandType = CommandType.StoredProcedure;
                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new Producto
                    {
                        IdProducto = Convert.ToInt32(rd["IdProducto"]),
                        CodigoBarra = string.IsNullOrEmpty(rd["CodigoBarra"].ToString()) ? "Null" : rd["CodigoBarra"].ToString(),
                        Nombre = string.IsNullOrEmpty(rd["Nombre"].ToString()) ? "Null" : rd["Nombre"].ToString(),
                        Marca = string.IsNullOrEmpty(rd["Marca"].ToString()) ? "Null" : rd["Marca"].ToString(),
                        categoria = string.IsNullOrEmpty(rd["Categoria"].ToString()) ? "Null" : rd["Categoria"].ToString(),
                        Precio = Convert.ToDecimal(rd["Precio"]),

                    });

                }
                return lista;

            }
            catch (Exception ex)
            {

                return lista;
            }
        }



        public Producto Obtener_Producto(int idProducto)
        {
            Producto oProducto = new Producto();
            SqlConnection cone = new SqlConnection(Constantes.conexion.Mece);

            try
            {


                cone.Open();
                var cmd = new SqlCommand(Constantes.Procedimientos.ObtenerLista, cone);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {

                        oProducto.IdProducto = Convert.ToInt32(rd["IdProducto"]);
                        oProducto.CodigoBarra = rd["CodigoBarra"].ToString();
                        oProducto.Nombre = rd["Nombre"].ToString();
                        oProducto.Marca = rd["Marca"].ToString();
                        oProducto.categoria = rd["Categoria"].ToString();
                        oProducto.Precio = Convert.ToDecimal(rd["Precio"]);
                    }
                }
                return oProducto;

            }
            catch (Exception ex)
            {
                return oProducto;

            }
            finally { cone.Close(); }

        }


        public Producto Guardar_producto(Producto objecto)
        {
            SqlConnection cone = new SqlConnection(Constantes.conexion.Mece);
            try
            {
                {
                    cone.Open();
                    var cmd = new SqlCommand(Constantes.Procedimientos.CrearProduct, cone);
                    cmd.Parameters.AddWithValue("codigoBarra", objecto.CodigoBarra);
                    cmd.Parameters.AddWithValue("nombre", objecto.Nombre);
                    cmd.Parameters.AddWithValue("marca", objecto.Marca);
                    cmd.Parameters.AddWithValue("categoria", objecto.categoria);
                    cmd.Parameters.AddWithValue("precio", objecto.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return objecto;


            }
            catch (Exception erro)
            {
                return objecto;

            }
            finally
            {
                cone.Close();
            }
        }


        public Producto Editar(Producto objecto)
        {
            SqlConnection conexion = new SqlConnection(Constantes.conexion.Mece);

            try
            {
                {
                    conexion.Open();
                    var cmd = new SqlCommand(Constantes.Procedimientos.EditarProducto, conexion);
                    cmd.Parameters.AddWithValue("idProducto", objecto.IdProducto == 0 ? DBNull.Value : objecto.IdProducto);
                    cmd.Parameters.AddWithValue("codigoBarra", objecto.CodigoBarra is null ? DBNull.Value : objecto.CodigoBarra);
                    cmd.Parameters.AddWithValue("nombre", objecto.Nombre is null ? DBNull.Value : objecto.Nombre);
                    cmd.Parameters.AddWithValue("marca", objecto.Marca is null ? DBNull.Value : objecto.Marca);
                    cmd.Parameters.AddWithValue("categoria", objecto.categoria is null ? DBNull.Value : objecto.categoria);
                    cmd.Parameters.AddWithValue("precio", objecto.Precio == 0 ? DBNull.Value : objecto.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return objecto;

            }
            catch (Exception erro)
            {
                return objecto;

            }


        }





        public bool Eliminar(int idProducto)
        {
            bool respuesta = false;
            SqlConnection conexion = new SqlConnection(Constantes.conexion.Mece);

            try
            {

                {
                    conexion.Open();
                    var cmd = new SqlCommand(Constantes.Procedimientos.Eliminar, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteReader();
                }

                return false;

            }
            catch (Exception ex)
            {

                return false;

            }

            finally { conexion.Close(); }

        }
    }
}