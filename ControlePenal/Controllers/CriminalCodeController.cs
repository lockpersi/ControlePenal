using ControlePenal.Application;
using ControlePenal.Context;
using ControlePenal.Entity.Models;
using ControlePenal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ControlePenal.Controllers
{
    [Route("api/CriminalApp")]
    [ApiController]
    public class CriminalCodeController :  ControllerBase
    {
        private IConfiguration _config;
        private ApiContext _context;

        public CriminalCodeController(IConfiguration configuration, ApiContext context)
        {
            _config = configuration;
            _context = context;
        }

        /// <summary>
        /// Criação de Codigo Penal
        /// </summary>
        /// <param name="criminalcode">Modelo para criação do Criminal Code</param>
        /// <response code="200">Retorno Sucesso criação</response>
        /// <response code="400">Retorno Falha criação</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]CriminalCodeModel criminalcode)
        {
            ResponseModel response = await new CriminalCodeApp(_context).CreateCriminalCodeAsync(criminalcode);

            if (response.Status == ResponseModel.StatusEnum.Sucess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        /// <summary>
        /// Deletar Codigo Penal
        /// </summary>
        /// <param name="id"> ID para deletar na base de dados</param>
        /// <response code="200">Retorno Sucesso deletado</response>
        /// <response code="400">Retorno Falha na tentativa de deletar</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            ResponseModel response = await new CriminalCodeApp(_context).DeleteCriminalCodeAsync(id);

            if (response.Status == ResponseModel.StatusEnum.Sucess) 
                return Ok(response);
            else 
                return BadRequest(response);


        }

        /// <summary>
        /// Filtrar codigo Penal
        /// </summary>
        /// <param name="filter">Campo para filtrar codigo penal</param>
        /// <param name="by">Coluna que será filtrado</param>
        /// <param name="orderBy">Coluna para ordenação</param>
        /// <param name="way">Caminho da ordenação: asc / desc </param>
        /// <param name="page">Pagina da ordenação</param>
        /// <response code="200">Retorno Sucesso Filtrado</response>
        /// <response code="400">Retorno Falha na tentativa de filtrar</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get([FromQuery] string filter = "", string by = "Name", string orderBy = "Name", string way = "asc", int page = 0)
        {
            CriminalResponseModel responseCriminal = await new CriminalCodeApp(_context).GetCriminalCodeAsync(filter, by, orderBy, way, page);

            if (responseCriminal.Status == ResponseModel.StatusEnum.Sucess) 
                return Ok(responseCriminal);
            else
                return BadRequest(responseCriminal);
        }

        /// <summary>
        /// Editar codigo penal
        /// </summary>
        /// <param name="id">Campo ID para editar na bse de dados</param>
        /// <param name="criminalCode">Objeto criminalCode para edição</param>
        /// <response code="200">Retorno Sucesso editar</response>
        /// <response code="400">Retorno Falha na tentativa de editar</response>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit/{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CriminalCodeModel criminalCode)
        {
            ResponseModel response = await new CriminalCodeApp(_context).EditCriminalCodeAsync(id, criminalCode);

            if (response.Status == ResponseModel.StatusEnum.Sucess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        /// <summary> 
        /// Buscar codigo penal
        /// </summary>
        /// <param name="id">ID para buscar na base de dados</param>
        /// <response code="200">Retorno Sucesso busca na Base</response>
        /// <response code="400">Retorno Falha na tentativa de buscar informação</response>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> Get([FromRoute]int id)
        {
            CriminalResponseModel responseCriminal = await new CriminalCodeApp(_context).GetAsync(id);

            if (responseCriminal.Status == ResponseModel.StatusEnum.Sucess)
                return Ok(responseCriminal);
            else
                return BadRequest(responseCriminal);
        }

    }
}
