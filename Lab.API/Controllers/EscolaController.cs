
using Microsoft.AspNetCore.Mvc;
using Lab.Api.Views;
using Lab.Domain.Interface.IService;
using OfficeOpenXml;
using Swashbuckle.AspNetCore.Annotations;

namespace Lab.Api.Controllers
{
    [Route("/Escolas")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _service;

        public EscolaController(IEscolaService ecolaService)
        {
            _service = ecolaService;
        }

        [HttpGet("ReadAll")]
        [SwaggerOperation(Summary = "Lista todas as escolas existentes")]
        public IActionResult GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var people = _service.FindAll().Select(ViewParser.Parse);
                return Ok(people);
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Cria uma nova escola")]
        public IActionResult Add([FromBody] EscolaView dado)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                _service.Save(dado.ConvertToDto());
                return Ok("Escola Criada com sucesso");
            }
            catch (Exception e)
            {
                //add logs
                if (e.Message.Equals("An error occurred while saving the entity changes. See the inner exception for details."))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Já existe uma escola com o nome {dado.Nome} ou dados demasiado extensos");
                }else  return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpPut("Update")]
        [SwaggerOperation(Summary = "Atualiza os dados de uma escola existente")]
        public IActionResult Put(EscolaView dado)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(dado.ConvertToDto());

                return Ok(dado);
            }
            catch (Exception e)
            {
                //add logs
                if (e.Message.Equals("An error occurred while saving the entity changes. See the inner exception for details."))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Já existe uma escola com o nome {dado.Nome} ou dados demasiado extensos");
                }else return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        [SwaggerOperation(Summary = "Excluir uma escola existente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Remove(id);

                return Ok();
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("ReadById/{id}")]
        [SwaggerOperation(Summary = "Recupera informações sobre uma escola específica")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _service.FindById(id);

                if (result == null) return NotFound();

                return Ok(ViewParser.Parse(result));
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet("ReadByNome/{nome}")]
        [SwaggerOperation(Summary = "Recupera informações sobre uma escola filtrando pelo nome")]
        public IActionResult GetByNome_da_Escola(string nome)
        {
            try
            {
                var result = _service.FindByNome(nome).Select(ViewParser.Parse);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("ReadByProvincia/{provincia}")]
        [SwaggerOperation(Summary = "Recupera informações sobre uma escola filtrando por província")]
        public IActionResult GetByProvincia(string provincia)
        {
            try
            {
                var result = _service.FindByProvincia(provincia).Select(ViewParser.Parse);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                //add logs
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }



        [HttpPost("UploadExcel")]
        [SwaggerOperation(Summary = "Faça o upload do arquivo excel de escolas para salvar no sistema")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Envie um arquivo válido.");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Apenas arquivos .xlsx são suportados.");
            }

            string Auxiliar_Nome_da_escola = string.Empty;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var listaEscolasView = new List<EscolaView>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 2].Value != null)
                            {
                                listaEscolasView.Add(new EscolaView
                                {
                                    Nome = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                    Email = worksheet.Cells[row, 3].Value?.ToString().Trim(),
                                    Numero_de_Salas = int.Parse(worksheet.Cells[row, 4].Value?.ToString().Trim()),
                                    Provincia = worksheet.Cells[row, 5].Value?.ToString().Trim()
                                });
                            }
                        }
                    }
                }

                foreach (var escolaview in listaEscolasView)
                {
                    Auxiliar_Nome_da_escola = escolaview.Nome;
                    _service.Save(escolaview.ConvertToDto());
                }

                return Ok("Dados das escolas carregado com sucesso.");
            }
            catch (Exception e)
            {
                //add logs
                if (e.Message.Equals("An error occurred while saving the entity changes. See the inner exception for details."))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Já existe uma escola com o nome {Auxiliar_Nome_da_escola} ou dados demasiado extensos");
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
