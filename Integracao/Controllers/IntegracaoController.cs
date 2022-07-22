using Integracao.Application.Importacoes.Interfaces;
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

        [HttpPost("validate")]
        public IActionResult Validate([FromForm] string fileName)
        {
            return Ok();
        }


        [HttpPost("import")]
        [AllowAnonymous]
        public IActionResult Insert([FromForm] ClasseArquivoEnum classe)
        {
            var file = Request.Form.Files[0];

            var result = _importacaoAppService.ImportarArquivos(file.FileName, classe, file.OpenReadStream(), OperadoraEnum.SulAmerica);
            return Ok(result);
        }
    }
}
