using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Members.MembersDto;
using Microsoft.EntityFrameworkCore;

namespace book_web_api.Services.Members
{
    public class MemberServicescs
    {
        EFDBContext _context = new EFDBContext();

        public void AddMember(AddMemberDto dto)
        {
            var mem = new Member();
            if (_context.members.Any(_ => _.Name == dto.Name))
            {
                throw new Exception("name should be unique");
            }
            mem.Name = dto.Name;
            mem.Email = dto.Email;
          
            _context.members.Add(mem);
            _context.SaveChanges();
        }
        public void UpdateMember(int id, UpdateMemberDtoscs dto)
        {
            var member = _context.members.FirstOrDefault(x => x.Id == id);
            if (member is null)
            {
                throw new Exception("user not found");
            }
            member.Name = dto.Name;
           member.Email = dto.Email;
            _context.members.Update(member);
            _context.SaveChanges();
        }
        public void DeleteMembers(int id)
        {
            var member = _context.members.FirstOrDefault(x => x.Id == id);
            if (member is null)
            {
                throw new Exception("user not found");
            }
            _context.members.Remove(member);
            _context.SaveChanges();
        }
        public List<Member> GetMember()
        {
           return _context.members.Include(_=>_.Rents).ToList();

        }
       


        public void AddMEmberRentBook(MemberAddRentBookDto dto)
        {
            var mem = _context.members.FirstOrDefault(_ => _.Name == dto.Name);
            if (mem is null)
            {
                throw new Exception("user not found");
            }
            var book = _context.Books.Find(dto.BookId);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            var bookRentCount = _context.Rents.Count(_ => _.UserId == mem.Id && _.BackBook == false);
            if (bookRentCount == 4)
            {
                throw new Exception("this user cant have more than 4 book to rent");
            }
            if (book.Inventory <= 0)
            {
                throw new Exception("we are out of stock choose anothor book");

            }
            var memRentBook = new Rent
            {
                BackBook = false,
                UserId = mem.Id,
                BookId = book.Id,

            };
            mem.Rents.Add(memRentBook);
            book.Inventory--;
            _context.SaveChanges();

        }
        public void UpdateMemberRentBook(UpdateMemberRentBookDTo dto)
        {
            var memRentBook = _context.Rents.FirstOrDefault(_ => _.UserId == dto.UserId && _.BookId == dto.BookId && _.BackBook == false);
            if (memRentBook is null)
            {
                throw new Exception("wrong info!!!");
            }
            memRentBook.BackBook = true;
            var book = _context.Books.Find(dto.BookId);
            book.Inventory++;
            _context.SaveChanges();
        }
    }
}

