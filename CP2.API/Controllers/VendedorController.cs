using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;   
        }

        /// <summary>
        /// Metodo para obter todos os dados do Vendedor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<VendedorEntity>>]
        public IActionResult Get()
        {
            var vendedor = _applicationService.ObterTodosVendedores();

            if (vendedor is not null)
                return Ok(vendedor);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para obter um vendedor
        /// </summary>
        /// <param name="id"> Identificador do vendedor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var vendedor = _applicationService.ObterVendedorPorId(id);

            if (vendedor is not null)
                return Ok(vendedor);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodos para salvar o vendedor
        /// </summary>
        /// <param name="entity"> Modelo de dados do Vendedor</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<VendedorEntity>]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var vendedor = _applicationService.SalvarDadosVendedor(entity);

                if (vendedor is not null)
                    return Ok(vendedor);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Metodos para editar o vendedor
        /// </summary>
        /// <param name="entity"> Modelo de dados do Vendedor</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var vendedor = _applicationService.EditarDadosVendedor(id, entity);

                if (vendedor is not null)
                    return Ok(vendedor);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Metodo para deletar um vendedor
        /// </summary>
        /// <param name="id"> Identificador do Vendedor</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Delete(int id)
        {
            var vendedor = _applicationService.DeletarDadosVendedor(id);

            if (vendedor is not null)
                return Ok(vendedor);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
