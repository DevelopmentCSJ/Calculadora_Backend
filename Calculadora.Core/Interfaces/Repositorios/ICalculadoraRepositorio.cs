using Calculadora.Core.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Core.Interfaces.Repositorios
{
    public interface ICalculadoraRepositorio
    {
        Task<Plantas> Add(IFormFile ArchivoExcell);
    }
}
