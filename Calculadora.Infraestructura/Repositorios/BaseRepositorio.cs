using Calculadora.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Infraestructura.Repositorios
{
    public class BaseRepositorio<T> where T : class
    {
        protected readonly CalculadoraContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepositorio(CalculadoraContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
    }
}
