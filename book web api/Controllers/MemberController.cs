using book.Entitis;
using book_web_api.Services.Members;
using book_web_api.Services.Members.MembersDto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class MemberController : ControllerBase
    {
        private readonly MemberServices _memberServices;

        public MemberController(MemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpPost("add-member")]
        public IActionResult AddMember([FromBody] AddMemberDto dto)
        {
            _memberServices.AddMember(dto);
            return Ok();
        }

        [HttpPost("add-member-rent-book")]
        public IActionResult AddMemberRentBook([FromBody] MemberAddRentBookDto dto)
        {
            _memberServices.AddMemberRentBook(dto);
            return Ok();
        }

        [HttpPatch("member-give-back-rent-book")]
        public IActionResult UpdateMemberRentBooks([FromBody] UpdateMemberRentBookDTo dto)
        {
            _memberServices.UpdateMemberRentBook(dto);
            return Ok();
        }

        [HttpPatch("update-member/{name}")]
        public IActionResult UpdateMember(string name, [FromBody] UpdateMemberDtoscs dto)
        {
            _memberServices.UpdateMember(name, dto);
            return Ok();
        }

        [HttpDelete("delete-member/{name}")]
        public IActionResult DeleteMember(string name)
        {
            _memberServices.DeleteMember(name);
            return Ok();
        }

        [HttpGet("get-member")]
        public IActionResult GetMembers()
        {
            var members = _memberServices.GetMembers();
            return Ok(members);
        }
    }
}
