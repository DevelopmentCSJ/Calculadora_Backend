using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using Calculadora.Core.Entidades;
using Calculadora.Core.Interfaces.Servicios;

namespace Calculadora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        private readonly ICalculadoraServicio _calculadoraServicio;

        public CalculadoraController(ICalculadoraServicio calculadoraServicio)
        {
            _calculadoraServicio = calculadoraServicio;
        }

        [HttpGet]
        /// <summary>
        /// Este metodo obtiene todos los libros almacenados en la BD
        /// </summary>
        public async Task<IActionResult> Calcular()
        {
            //var lstLibros = await _librosServicio.GetLibros();
            var response = new JsonResultApi()
            {
                Success = true,
                Data = null,
                Message = "Consulta exitosa"
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> leerArchivo([FromForm] IFormFile ArchivoExcell)
        {

            var objPlantas = await _calculadoraServicio.InsertarPlantas(ArchivoExcell);
            var response = new JsonResultApi()
            {
                Success = true,
                Data = objPlantas,
                Message = "Lectura exitosa"
            };
            return Ok(response);
        }
    }
}
