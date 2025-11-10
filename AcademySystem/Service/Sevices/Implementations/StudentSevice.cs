using Domain.Entities;
using Repository.Repostories.Implementations;
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
        private int _count = 1;
        private GroupsRepository _groupsRepository;
        private StudentRepository _studentRepository;

        public StudentSevice()
        {
            _groupsRepository = new GroupsRepository();
            _studentRepository = new StudentRepository();
        }
        public Student CreateStudent(int groupId, Student student)
        {
            var groups =_groupsRepository.GetAllGroups(g=>g.Id == groupId);
            if (groups is null) return null;
            student.Id = _count;
            _count++;
            _studentRepository.CreateStudent(student);
            return student;
        }

        public void DeleteStudent(int id)
        {
            Student student=Getstudentbyid(id);
            _studentRepository.DeleteStudent(student);
        }

        public List<Student> GetAllStudentsByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student Getstudentbyid(int id)
        {
            Student student = _studentRepository.Getstudentbyid(s=>s.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepository(s => s.Age == age);
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
