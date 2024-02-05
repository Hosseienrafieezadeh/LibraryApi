using book.Entitis;
using book_web_api.Services.Members;
using book_web_api.Services.Members.MembersDto;
using Microsoft.AspNetCore.Mvc;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class MemberController
    {
        MemberServicescs _MemberSErveices = new MemberServicescs();

        [HttpPost("add-member")]
        public void AddUMember([FromBody] AddMemberDto dto)
        {
            _MemberSErveices.AddMember(dto);
        }
        [HttpPost("add-member-rent-book")]
        public void AddMemberRentBook([FromBody] MemberAddRentBookDto dto)
        {
            _MemberSErveices.AddMEmberRentBook(dto);
        }
        [HttpPatch("member-give-back-rent-book/")]
        public void UpdateMemberRentBooks([FromBody] UpdateMemberRentBookDTo dto)
        {
            _MemberSErveices.UpdateMemberRentBook(dto);
        }
        [HttpPatch("update-member/{id}")]
        public void UpdateMember([FromRoute] int id, [FromBody] UpdateMemberDtoscs dto)
        {
            _MemberSErveices.UpdateMember(id, dto);
        }
        [HttpDelete("delete-member/{id}")]
        public void DeleteMember([FromRoute] int id)
        {
            _MemberSErveices.DeleteMembers(id);
        }
        [HttpGet("get-member")]
        public List<Member> GetMemberByName()
        {
            return _MemberSErveices.GetMember();
        }
       
    }
}
