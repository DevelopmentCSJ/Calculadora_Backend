using Calculadora.Core.Interfaces;
using Calculadora.Core.Interfaces.Repositorios;
using Calculadora.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Infraestructura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalculadoraContext _context;
        private readonly ICalculadoraRepositorio _calculadoraRepositorio;

        public UnitOfWork(CalculadoraContext context)
        {
            _context = context;
        }

        public ICalculadoraRepositorio CalculadoraRepositorio => _calculadoraRepositorio ?? new CalculadoraRepositorio(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
