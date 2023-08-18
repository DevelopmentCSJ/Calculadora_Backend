using Calculadora.Core.DTOs;
using Calculadora.Core.Entidades;
using Calculadora.Core.Interfaces;
using Calculadora.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Core.Servicios
{
    public class CalculadoraServicio : ICalculadoraServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalculadoraServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Plantas>> InsertarPlantas(IFormFile ArchivoExcell)
        {
            List<Plantas> lstPlantas = await _unitOfWork.CalculadoraRepositorio.Add(ArchivoExcell);

            return lstPlantas;
        }
    }
}
