using DapperNotes.Models;
using DapperNotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Services
{
    public class CourseService
    {
        private CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public int AddCourse(Course course)
        {
            return _courseRepository.Add(course);
        }

        public int UpdateCourse(Course course, int id)
        {
            return _courseRepository.Update(course, id);
        }

        public int DeleteCourse(int id)
        {
            return _courseRepository.Delete(id);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.Get();
        }

        public IEnumerable<Course> GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }
    }
}
