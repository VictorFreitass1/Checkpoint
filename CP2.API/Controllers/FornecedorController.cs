using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Metodo para obter todos os dados do Fornecedor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var fornecedor = _applicationService.ObterTodosFornecedores();

            if (fornecedor is not null)
                return Ok(fornecedor);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para obter um fornecedor
        /// </summary>
        /// <param name="id"> Identificador do fornecedor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var fornecedor = _applicationService.ObterFornecedorPorId(id);

            if (fornecedor is not null)
                return Ok(fornecedor);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodos para salvar o fornecedor
        /// </summary>
        /// <param name="entity"> Modelo de dados do Fornecedor</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedor = _applicationService.SalvarDadosFornecedor(entity);

                if (fornecedor is not null)
                    return Ok(fornecedor);

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
        /// Metodos para editar o fornecedor
        /// </summary>
        /// <param name="id"> Identificador do Fornecedor</param>
        /// <param name="entity"> Modelo de dados do Fornecedor</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedor = _applicationService.EditarDadosFornecedor(id, entity);

                if (fornecedor is not null)
                    return Ok(fornecedor);

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
        /// Metodo para deletar um fornecedor
        /// </summary>
        /// <param name="id"> Identificador do fornecedor</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var fornecedor = _applicationService.DeletarDadosFornecedor(id);

            if (fornecedor is not null)
                return Ok(fornecedor);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
