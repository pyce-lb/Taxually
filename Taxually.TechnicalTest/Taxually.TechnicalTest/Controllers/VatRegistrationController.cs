using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private static readonly TaxuallyHttpClient _httpClient = new TaxuallyHttpClient();

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request, CancellationToken cancellationToken)
        {
            switch (request.Country)
            {
                case Country.GreatBritain:
                    // UK has an API to register for a VAT number
                    await _httpClient.PostAsync("https://api.uktax.gov.uk", request, cancellationToken);
                    break;
                case Country.France:
                    // France requires an excel spreadsheet to be uploaded to register for a VAT number
                    var csvBuilder = new StringBuilder();
                    csvBuilder.AppendLine("CompanyName,CompanyId");
                    csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
                    var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
                    var excelQueueClient = new TaxuallyQueueClient();
                    // Queue file to be processed
                    await excelQueueClient.EnqueueAsync("vat-registration-csv", csv, cancellationToken);
                    break;
                case Country.Germany:
                    // Germany requires an XML document to be uploaded to register for a VAT number
                    using (var stringwriter = new StringWriter())
                    {
                        var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                        serializer.Serialize(stringwriter, this);
                        var xml = stringwriter.ToString();
                        var xmlQueueClient = new TaxuallyQueueClient();
                        // Queue xml doc to be processed
                        await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml, cancellationToken);
                    }
                    break;
                default:
                    throw new UnreachableException("Country not supported");

            }
            return Ok();
        }
    }
}
