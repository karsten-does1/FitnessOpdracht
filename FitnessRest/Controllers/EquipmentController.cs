using FitnessBL.Interfaces;
using FitnessDL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            var equipment = _equipmentService.GetAllEquipment();
            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipmentById(int id)
        {
            var equipment = _equipmentService.GetEquipmentById(id);
            if (equipment == null)
            {
                return NotFound("Equipment not found.");
            }
            return Ok(equipment);
        }

        [HttpPost]
        public IActionResult AddEquipment([FromBody] Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                return BadRequest("Invalid equipment data.");
            }

            _equipmentService.AddEquipment(newEquipment);
            return CreatedAtAction(nameof(GetEquipmentById), new { id = newEquipment.EquipmentId }, newEquipment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEquipment(int id, [FromBody] Equipment updatedEquipment)
        {
            try
            {
                _equipmentService.UpdateEquipment(id, updatedEquipment);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            try
            {
                _equipmentService.DeleteEquipment(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/maintenance")]
        public IActionResult SetMaintenance(int id, [FromQuery] bool isInMaintenance)
        {
            try
            {
                _equipmentService.SetMaintenance(id, isInMaintenance);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


