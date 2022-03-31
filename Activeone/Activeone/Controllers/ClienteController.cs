using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Activeone.Core.DTOs;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Repositories;
using Activeone.Response;

namespace Activeone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _maper;
        public ClienteController(IClienteRepository postRepository, IMapper mapper)
        {
            _clienteRepository = postRepository;
            _maper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var cliente = await _clienteRepository.GetClientes();
            var clientedto = _maper.Map<IEnumerable<ClienteDtos>>(cliente);
            return Ok(clientedto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetCliente(id);
            var clientedto = _maper.Map<ClienteDtos>(cliente);
            return Ok(clientedto);
        }
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteDtos clientedto)
        {
            var cliente = _maper.Map<Cliente>(clientedto);
            await _clienteRepository.InsertCliente(cliente);
            return Ok(clientedto);
        }
        [HttpPut]
        public async Task<IActionResult> PutCliente(int id,ClienteDtos cliente)
        {
            var clientedto = _maper.Map<Cliente>(cliente);
            clientedto.IdCliente = id;
            var Update = await _clienteRepository.UpdateCliente(clientedto);
            var updatecliente = new ApiResponse<bool>(Update);
            return Ok(updatecliente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            
            var result = await _clienteRepository.DeleteCliente(id);
            var deletecliente = new ApiResponse<bool>(result);
            return Ok(deletecliente);
        }
    }
}
