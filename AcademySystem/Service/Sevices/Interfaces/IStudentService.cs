using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Sevices.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(int groupId ,Student student);
        Student UpdateStudent(Student student);
        Student Getstudentbyid(int id);
        void DeleteStudent(int id);
        
        List<Student> GetAllStudentsByGroupId(int groupId);
        List<Student> SearchMethodForStudentsByNameOrSurname(string nameOrSurname);
        List<Student> GetStudentsByAge(int age);
    }
}
