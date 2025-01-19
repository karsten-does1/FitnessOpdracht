using Microsoft.AspNetCore.Mvc;
using FitnessBL.Interfaces;
using FitnessDL.Models;


namespace FitnessRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Member not found.");
            }
            return Ok(member);
        }

        [HttpPost]
        public IActionResult AddMember([FromBody] Member newMember)
        {
            if (newMember == null)
            {
                return BadRequest("Invalid member data.");
            }

            _memberService.AddMember(newMember);

            return CreatedAtAction(nameof(GetMemberById), new { id = newMember.MemberId }, newMember);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] Member updatedMember)
        {
            try
            {
                _memberService.UpdateMember(id, updatedMember);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                _memberService.DeleteMember(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }
    }
}

