using MeliTest.Core.Entities;
using MeliTest.Core.Interface;
using MeliTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeliTest.Infrastructure.Repositories
{
    public class DivisionRepository : IContainerRepository
    {
        private readonly MeliTestContext _context;
        public DivisionRepository(MeliTestContext context)
        {
            _context = context;
        }

        public DivisionRepository()
        {
        }

        public async Task<IEnumerable<TbContenedores>> GetAll()
        {
            var divs = await _context.TbContenedores.ToListAsync();
            return (divs);
        }

        public async Task<bool> Insert(TbContenedores contenedores)
        {
            _context.Add(contenedores);

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<IEnumerable<TbContenedores>> GetStats()
        {
            var contenedores = await _context.TbContenedores.ToListAsync();
            return (contenedores);
        }

    }
}
