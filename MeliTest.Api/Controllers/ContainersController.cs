using MeliTest.Api.Responses;
using MeliTest.Core.Entities;
using MeliTest.Core.DTOs;
using MeliTest.Core.Interfaces;
using MeliTest.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeliTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService _containerService;

        public ContainersController(IContainerService containerService)
        {
            _containerService = containerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ContainersQueryFilter filters)
        {
            var divs = await _containerService.GetAll(filters);
            if (divs == null) { return NotFound(); }

            var response = new ApiResponse<IEnumerable<TbContenedores>>(divs);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Insert(TbContenedores contenedores)
        {
            string menx = "Could not insert record";
            var respx = await _containerService.Insert(contenedores);
            if (respx) { menx = "The record was inserted correctly."; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats(int budgetUsed)
        {
            var containers = await _containerService.GetStats(budgetUsed);
            if (containers == null) { return NotFound(); }

            var response = new ApiResponse<KPIDto>(containers);
            return Ok(response);
        }
    }
}
