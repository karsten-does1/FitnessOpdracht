using FitnessBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FitnessDL.Models;


namespace FitnessRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public IActionResult GetAllPrograms()
        {
            var programs = _programService.GetAllPrograms();
            return Ok(programs);
        }

        [HttpGet("{programCode}")]
        public IActionResult GetProgramByCode(string programCode)
        {
            var program = _programService.GetProgramByCode(programCode);
            if (program == null)
            {
                return NotFound("Program not found.");
            }
            return Ok(program);
        }

        [HttpPost]
        public IActionResult AddProgram([FromBody] FitnessProgram newProgram)
        {
            if (newProgram == null)
            {
                return BadRequest("Invalid program data.");
            }

            _programService.AddProgram(newProgram);
            return CreatedAtAction(nameof(GetProgramByCode), new { programCode = newProgram.ProgramCode }, newProgram);
        }

        [HttpPut("{programCode}")]
        public IActionResult UpdateProgram(string programCode, [FromBody] FitnessProgram updatedProgram)
        {
            try
            {
                _programService.UpdateProgram(programCode, updatedProgram);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{programCode}")]
        public IActionResult DeleteProgram(string programCode)
        {
            try
            {
                _programService.DeleteProgram(programCode);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

