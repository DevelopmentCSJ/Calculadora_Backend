using Calculadora.Core.Entidades;
using Calculadora.Core.Interfaces.Repositorios;
using Calculadora.Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Infraestructura.Repositorios
{
    public class CalculadoraRepositorio : BaseRepositorio<List<Plantas>>, ICalculadoraRepositorio
    {
        public CalculadoraRepositorio(CalculadoraContext context) : base(context)
        {
        }

        public async Task<List<Plantas>> Add(IFormFile ArchivoExcell)
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
                    Nombre = fila.GetCell(0).ToString(),
                    Apellido = fila.GetCell(1).ToString(),
                    Telefono = fila.GetCell(2).ToString(),
                    Correo = fila.GetCell(3).ToString()
                });
            }
            return lstPlantas;
        }
    }
}
