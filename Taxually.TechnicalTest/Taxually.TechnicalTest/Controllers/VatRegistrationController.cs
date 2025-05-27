using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Contract;
using Taxually.TechnicalTest.Mappings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class VatRegistrationController : ControllerBase
    {
        private readonly VatRegistrationCommandHandlerFactory _commandHandlerFactory;
        private readonly VatRegistrationRequestMapper _mapper;

        public VatRegistrationController(VatRegistrationCommandHandlerFactory commandHandlerFactory, VatRegistrationRequestMapper mapper)
        {
            _commandHandlerFactory = commandHandlerFactory;
            _mapper = mapper;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(request);
            var country = _mapper.Map(request.Country);

            var commandHandler = _commandHandlerFactory.Create(country);
            await commandHandler.HandleAsync(command, cancellationToken);

            return Ok();
        }
    }
}
