using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using DapperNotes.Repositories;

namespace DapperNotes.Services
{
    public class StudentService
    {
        private StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public int AddStudent(Student student) 
        {
            return _studentRepository.Add(student);
        }

        public int UpdateStudent(Student student, int id)
        {
            return _studentRepository.Update(student, id);
        }

        public int DeleteStudent(int id)
        {
            return _studentRepository.Delete(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.Get();
        }

        public IEnumerable<Student> GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
