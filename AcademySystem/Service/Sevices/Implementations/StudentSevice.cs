using Domain.Entities;
using Service.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Sevices.Implementations
{
    public class StudentSevice : IStudentService
    {
        public Student CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student Getstudentbyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsByAge(int ageId)
        {
            throw new NotImplementedException();
        }

        public Student SearchMethodForGroupsByName(string groupByName, Student student)
        {
            throw new NotImplementedException();
        }

        public Student SearchMethodForStudentsByNameOrSurname(string studentName, Student student)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
