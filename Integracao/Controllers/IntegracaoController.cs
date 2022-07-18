using Integracao.Domain.Base.Repositories;
using Integracao.Infra.Repositories;
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
        public IActionResult Get()
        {
            _beneficiarioRepository.Insert();
            return Ok();
        }
    }
}
