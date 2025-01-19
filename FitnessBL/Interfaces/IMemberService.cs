using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDL.Models;

namespace FitnessBL.Interfaces
{
    public interface IMemberService
    {
        Member GetMemberById(int id);
        IEnumerable<Member> GetAllMembers();
        void AddMember(Member member);
        void UpdateMember(int id, Member member);
        void DeleteMember(int id);
    }
}
