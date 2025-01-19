using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBL.Interfaces;
using FitnessDL; // Data Layer namespace
using System.Collections.Generic;
using System.Linq;
using FitnessDL.Models;


namespace FitnessBL.Services
{
    public class MemberService : IMemberService
    {
        private readonly GymTestContext _context;

        public MemberService(GymTestContext context)
        {
            _context = context;
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(m => m.MemberId == id);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(int id, Member member)
        {
            var existingMember = _context.Members.FirstOrDefault(m => m.MemberId == id);
            if (existingMember == null)
                throw new KeyNotFoundException("Member not found.");

            existingMember.FirstName = member.FirstName;
            existingMember.LastName = member.LastName;
            existingMember.Email = member.Email;
            existingMember.Address = member.Address;
            existingMember.Birthday = member.Birthday;
            existingMember.Interests = member.Interests;
            existingMember.Membertype = member.Membertype;

            _context.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            var member = _context.Members.FirstOrDefault(m => m.MemberId == id);
            if (member == null)
                throw new KeyNotFoundException("Member not found.");

            _context.Members.Remove(member);
            _context.SaveChanges();
        }
    }
}

