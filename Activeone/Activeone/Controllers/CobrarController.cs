using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Activeone.Core.DTOs;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Repositories;
using Activeone.Response;

namespace Activeone.Controllers
{
    public class CobrarController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ClienteController : ControllerBase
        {
            private readonly ICobrarRepository _cobrarRepository;

            public ClienteController(ICobrarRepository cobrarRepository)
            {
                _cobrarRepository = cobrarRepository;

            }
            [HttpGet]
            public async Task<IActionResult> GetClientes()
            {
                var Cobrar = await _cobrarRepository.CobrarAlquile();
                return Ok(Cobrar);
            }
        }
    }
}
