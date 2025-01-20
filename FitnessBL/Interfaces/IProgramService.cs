using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDL.Models;

namespace FitnessBL.Interfaces
{
    public interface IProgramService
    {
        IEnumerable<FitnessProgram> GetAllPrograms();
        FitnessProgram GetProgramByCode(string programCode);
        void AddProgram(FitnessProgram program);
        void UpdateProgram(string programCode, FitnessProgram program);
        void DeleteProgram(string programCode);
    }
}
