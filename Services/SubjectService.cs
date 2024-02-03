using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using DapperNotes.Repositories;

namespace DapperNotes.Services
{
    public class SubjectService
    {
        private SubjectRepository _subjectRepository;

        public SubjectService(SubjectRepository subjectRepository) 
        {
            _subjectRepository = subjectRepository;
        }

        public int AddSubject(Subject subject)
        {
            return _subjectRepository.Add(subject);
        }

        public int UpdateSubject(Subject subject, int id)
        {
            return _subjectRepository.Update(subject, id);
        }

        public int DeleteSubject(int id)
        {
            return _subjectRepository.Delete(id);
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _subjectRepository.Get();
        }

        public IEnumerable<Subject> GetSubjectById(int id)
        {
            return _subjectRepository.GetById(id);
        }
    }
}
