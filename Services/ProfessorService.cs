using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Repositories;
using DapperNotes.Models;

namespace DapperNotes.Services
{
    public class ProfessorService
    {
        private ProfessorRepository _professorRepository;
        public ProfessorService(ProfessorRepository professorRepository) 
        {
            _professorRepository = professorRepository;
        }

        public int AddProfessor(Professor professor)
        {
            return _professorRepository.Add(professor);
        }

        public int UpdateProfessor(Professor professor, int id)
        {
            return _professorRepository.Update(professor, id);
        }

        public int DeleteProfessor(int id)
        {
            return _professorRepository.Delete(id);
        }

        public IEnumerable<Professor> GetProfessors()
        {
            return _professorRepository.Get();
        }

        public IEnumerable<Professor> GetProfessorById(int id)
        {
            return _professorRepository.GetById(id);
        }
    }
}
