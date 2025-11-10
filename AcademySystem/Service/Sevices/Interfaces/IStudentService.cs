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
        List<Student> GetStudentsByAge(int age);
        List<Student> GetAllStudentsByGroupId(int groupId);
        Student SearchMethodForGroupsByName(string groupByName,Student student);//bax
        Student SearchMethodForStudentsByNameOrSurname(string studentName,Student student);//bax

    }
}
