using FitnessBL.Interfaces;
using FitnessDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class ProgramService : IProgramService
    {
        private readonly GymTestContext _context;

        public ProgramService(GymTestContext context)
        {
            _context = context;
        }

        public IEnumerable<FitnessProgram> GetAllPrograms()
        {
            return _context.Programs.ToList();
        }

        public FitnessProgram GetProgramByCode(string programCode)
        {
            return _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
        }

        public void AddProgram(FitnessProgram program)
        {
            _context.Programs.Add(program);
            _context.SaveChanges();
        }

        public void UpdateProgram(string programCode, FitnessProgram program)
        {
            var existingProgram = _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
            if (existingProgram == null)
                throw new KeyNotFoundException("Program not found.");

            existingProgram.Name = program.Name;
            existingProgram.Target = program.Target;
            existingProgram.Startdate = program.Startdate;
            existingProgram.MaxMembers = program.MaxMembers;

            _context.SaveChanges();
        }

        public void DeleteProgram(string programCode)
        {
            var program = _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
            if (program == null)
                throw new KeyNotFoundException("Program not found.");

            _context.Programs.Remove(program);
            _context.SaveChanges();
        }
    }
}

