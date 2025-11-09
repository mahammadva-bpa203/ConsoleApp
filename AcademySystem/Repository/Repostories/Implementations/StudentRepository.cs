using Domain.Entities;
using Repository.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Implementations
{
    public class StudentRepository : IRepositoryStudent<Student>
    {
        public void CreateStudent(Student data)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student data)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByGroupId(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student Getstudentbyid(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentsByAge(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student SearchMethodForGroupsByName(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student SearchMethodForStudentsByNameOrSurname(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
