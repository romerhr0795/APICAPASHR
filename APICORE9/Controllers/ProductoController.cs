using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using ProductoENTITIES;
using ProductosBL;

namespace APICORE9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly string categoria;

        public ProductoController(IConfiguration config)
        {
            categoria = config.GetConnectionString("cadenaSql");
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection(Constantes.conexion.Mece);

            try
            {




                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista llamda con exito", Response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Response = lista });
            }
        }
        [HttpGet]
        [Route("Obtener_Producto/{idProducto:int}")]

        public IActionResult Obtener_Producto(int idProducto)
        {
            Producto oProducto = new Producto();
            SqlConnection cone = new SqlConnection(Constantes.conexion.Mece);

            try
            {




                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Producto traido con exito", Response = oProducto });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Response = oProducto });

            }
            finally { cone.Close(); }

        }
        [HttpPost]
        [Route("Guardar_producto")]

        public IActionResult Guradar_producto([FromBody] Producto objecto)
        {
            SqlConnection cone = new SqlConnection(Constantes.conexion.Mece);
            try
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Producto Editado con exito" });


            }
            catch (Exception erro)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erro.Message });

            }
            finally
            {
                cone.Close();
            }
        }

        [HttpPut]
        [Route("Editar")]

        public IActionResult Editar([FromBody] Producto objecto)
        {
            SqlConnection conexion = new SqlConnection(Constantes.conexion.Mece);

            try
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "producto editado con exito" });

            }
            catch (Exception erro)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erro.Message });

            }
        }
        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]

        public IActionResult Eliminar(int idProducto)
        {
            SqlConnection conexion = new SqlConnection(Constantes.conexion.Mece);

            try
            {

               

                return StatusCode(statusCode: StatusCodes.Status200OK, new { mensaje = "Producto Eliminado con exito" });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error" });

            }

            finally { conexion.Close(); }

        }
    }
    }


