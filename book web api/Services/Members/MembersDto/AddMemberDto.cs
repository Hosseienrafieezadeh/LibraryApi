using System.ComponentModel.DataAnnotations;

namespace book_web_api.Services.Members.MembersDto
{
    public class AddMemberDto
    {
        public string Name { get; set; }
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
