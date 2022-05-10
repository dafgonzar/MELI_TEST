using MeliTest.Core.Entities;
using MeliTest.Core.DTOs;
using MeliTest.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeliTest.Core.Interfaces
{
    public interface IContainerService
    {
        Task<IEnumerable<TbContenedores>> GetAll(ContainersQueryFilter filters);
        Task<KPIDto> GetStats(int budgetUsed);
        Task<bool> Insert(TbContenedores contenedores);

    }
}
