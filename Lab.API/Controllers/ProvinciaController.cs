
using Microsoft.AspNetCore.Mvc;
using Lab.Api.Views;
using Lab.Domain.Interface.IService;
using OfficeOpenXml;
using Swashbuckle.AspNetCore.Annotations;
using Web.Api.Views;
using Newtonsoft.Json;

namespace Lab.Api.Controllers
{
    [Route("/Provincias")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        public ProvinciaController()
        {
        }

       [HttpGet("ReadAll")]
       [SwaggerOperation(Summary = "Lista de Províncias Disponíveis")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Angola = new Dictionary<string, AngolaView>();
                using (StreamReader reading = new StreamReader(@"ProvinceData/province.json"))
                {
                    var json = reading.ReadToEnd();
                    Angola = JsonConvert.DeserializeObject<Dictionary<string, AngolaView>>(json);
                }
                return Ok(Angola);
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
 
    }
}
