using DapperNotes.Models;
using DapperNotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Services
{
    public class EnrollmentService
    {
        public EnrollmentRepository _enrollmentRepository;

        public EnrollmentService(EnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public int AddEnrollment(Enrollment enrollment, int studentId, int courseId)
        {
            return _enrollmentRepository.Add(enrollment);
        }

        public int UpdateEnrollment(Enrollment enrollment, int id, int studentId, int courseId)
        {
            return _enrollmentRepository.Update(enrollment, id);
        }

        public int DeleteEnrollment(int id)
        {
            return _enrollmentRepository.Delete(id);
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _enrollmentRepository.Get();
        }

        public IEnumerable<Enrollment> GetEnrollmentById(int id)
        {
            return _enrollmentRepository.GetById(id);
        }
    }
}
