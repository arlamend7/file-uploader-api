using Integracao.Application.Importacoes.DatasTransfer.Requests;
using Integracao.Application.Importacoes.DatasTransfer.Responses;
using Integracao.Application.Importacoes.Interfaces;
using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegracaoController : ControllerBase
    {
        IManipulationRepository _manipulationRepository;
        BeneficiarioRepository _beneficiarioRepository;
        IImportacaoAppService _importacaoAppService;
        public IntegracaoController(IManipulationRepository manipulationRepository, BeneficiarioRepository beneficiarioRepository, IImportacaoAppService importacaoAppService)
        {
            _manipulationRepository = manipulationRepository;
            _beneficiarioRepository = beneficiarioRepository;
            _importacaoAppService = importacaoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            
            return Ok();
        }

        [HttpPost("import")]
        [AllowAnonymous]
        public IActionResult Insert([FromForm] FileImportInsertRequest request)
        {
            IFormFile file = Request.Form.Files[0];

            Guid result = _importacaoAppService.InsertValuesFile(file.FileName, file.OpenReadStream(), request);
            return Ok(result);
        }

        [HttpPost("validate")]
        [AllowAnonymous]
        public IActionResult Validate([FromForm] FileImportInsertRequest request)
        {
            IFormFile file = Request.Form.Files[0];

            var result = _importacaoAppService.ValidateFile(file.OpenReadStream(), request);
            return Ok(result);
        }
    }
}
