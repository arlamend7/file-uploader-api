using Integracao.Domain.Base.Repositories;
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
        public IntegracaoController(IManipulationRepository manipulationRepository, BeneficiarioRepository beneficiarioRepository)
        {
            _manipulationRepository = manipulationRepository;
            _beneficiarioRepository = beneficiarioRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("import")]
        [AllowAnonymous]
        public IActionResult Insert([FromForm] string fileName)
        {
            Stream file = Request.Form.Files[0].OpenReadStream();
            return Ok();
        }
    }
}
