using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Members.MembersDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace book_web_api.Services.Members
{
    public class MemberServices
    {
        private readonly EFDBContext _context;

        public MemberServices(EFDBContext context)
        {
            _context = context;
        }

        public void AddMember(AddMemberDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email
            };

            _context.members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(string name, UpdateMemberDtoscs dto)
        {
            var member = _context.members.FirstOrDefault(m => m.Name == name);

            if (member == null)
            {
                throw new Exception("Member not found.");
            }

            member.Name = dto.Name;
            member.Email = dto.Email;

            _context.SaveChanges();
        }

        public void DeleteMember(string name)
        {
            var member = _context.members.FirstOrDefault(m => m.Name == name);

            if (member == null)
            {
                throw new Exception("Member not found.");
            }

            _context.members.Remove(member);
            _context.SaveChanges();
        }

        public List<Member> GetMembers()
        {
            return _context.members.Include(m => m.Rents).ToList();
        }

        public void AddMemberRentBook(MemberAddRentBookDto dto)
        {
            var member = _context.members.FirstOrDefault(m => m.Name == dto.Name);
            if (member == null)
            {
                throw new Exception("Member not found. Please try again later.");
            }

            var book = _context.Books.Find(dto.BookId);
            if (book == null)
            {
                throw new Exception("Book not found.");
            }

            var memRentBook = new Rent
            {
                BackBook = false,
                Member = member,
                Book = book
            };

            _context.Rents.Add(memRentBook);
            book.Inventory--;
            _context.SaveChanges();
        }

        public void UpdateMemberRentBook(UpdateMemberRentBookDTo dto)
        {
            var memRentBook = _context.Rents.FirstOrDefault(r => r.UserId == dto.UserId && r.BookId == dto.BookId && !r.BackBook);
            if (memRentBook == null)
            {
                throw new Exception("The specified rent book does not exist or has been returned already.");
            }

            memRentBook.BackBook = true;

            var book = _context.Books.Find(dto.BookId);
            if (book == null)
            {
                throw new Exception("The specified book does not exist.");
            }

            book.Inventory++;
            _context.SaveChanges();
        }
    }
}
