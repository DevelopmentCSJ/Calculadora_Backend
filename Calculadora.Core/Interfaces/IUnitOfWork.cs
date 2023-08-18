using Calculadora.Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICalculadoraRepositorio CalculadoraRepositorio { get; }
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
