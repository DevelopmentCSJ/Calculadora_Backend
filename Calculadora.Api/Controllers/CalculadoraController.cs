using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using Calculadora.Core.Entidades;

namespace Calculadora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

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

            Stream stream = ArchivoExcell.OpenReadStream();
            IWorkbook workbook = null;
            if (Path.GetExtension(ArchivoExcell.FileName) == ".xlsx")
            {
                workbook = new XSSFWorkbook(stream);
            }
            else
            {
                workbook = new XSSFWorkbook(stream);
            }

            ISheet hojaExcell = workbook.GetSheetAt(0);

            int cantidadFilas = hojaExcell.LastRowNum;

            List<Plantas> lstPlantas = new List<Plantas>();

            for (int i = 1; i <= hojaExcell.LastRowNum; i++)
            {
                IRow fila = hojaExcell.GetRow(i);

                lstPlantas.Add(new Plantas
                {
                    nombre = fila.GetCell(0).ToString(),
                    apellido = fila.GetCell(1).ToString(),
                    telefono = fila.GetCell(2).ToString(),
                    correo = fila.GetCell(3).ToString()
                });
            }
            var response = new JsonResultApi()
            {
                Success = true,
                Data = lstPlantas,
                Message = "Lectura exitosa"
            };
            return Ok(response);
        }
    }
}
