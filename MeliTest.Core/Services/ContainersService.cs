using MeliTest.Core.Entities;
using MeliTest.Core.DTOs;
using MeliTest.Core.Interface;
using MeliTest.Core.Interfaces;
using MeliTest.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliTest.Core.Services
{
    public class ContainersService : IContainerService
    {
        private readonly IContainerRepository _divisionRepository;
        public ContainersService(IContainerRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public async Task<IEnumerable<TbContenedores>> GetAll(ContainersQueryFilter filters)
        {
            var divs = await _divisionRepository.GetAll();

            if (filters.NombreContenedor != null)
            {
                divs = divs.Where(x => x.NombreContenedor.Trim() == filters.NombreContenedor);
            }

            return divs;
        }
        public async Task<KPIDto> GetStats(int budgetUsed)
        {
            var containers = await _divisionRepository.GetStats();
            decimal sum = 0;
            var totalContainers = containers.Count();
            decimal result = 0;
            decimal resultDispatched = 0;
            decimal resultNotDispatched = 0;
            decimal containersNotDispatched = 0;


            for (int i = 0; i <= containers.Count()/2; i++)
            {
                totalContainers = totalContainers - 1;   
                sum = containers.ElementAt(i).CostoTransporte + containers.ElementAt(totalContainers).CostoTransporte;
                result = result + sum;

                if (result > budgetUsed)
                {
                    result = result - sum;                       
                    if (i == totalContainers)
                    {
                        containersNotDispatched = containers.ElementAt(totalContainers).ValorContainer;                        
                    }
                    else
                    {
                        containersNotDispatched = containers.ElementAt(totalContainers).ValorContainer + containers.ElementAt(i).ValorContainer;
                    }
                    resultNotDispatched = resultNotDispatched + containersNotDispatched;
                }
                else
                {
                    decimal containersDispatched = containers.ElementAt(totalContainers).ValorContainer + containers.ElementAt(i).ValorContainer;
                    resultDispatched = resultDispatched + containersDispatched;
                }                
            }            

            KPIDto respDto = new KPIDto
            {
                ContainersDispached = resultDispatched,
                ContainersNotDispached = resultNotDispatched,
                BudgetUsed = budgetUsed
            };

            return respDto;
        }

        public async Task<bool> Insert(TbContenedores sccplDivisiones)
        { 
            return await _divisionRepository.Insert(sccplDivisiones);
        }

    }
}
