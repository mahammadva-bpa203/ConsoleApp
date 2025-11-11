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
            var groups =_groupsRepository.Get(g=>g.Id == groupId);
            if (groups is null) return null;
            student.Id = _count;
            student.Group = groups;
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
            List<Student> students = _studentRepository.GetAll(s => s.Group.Id == groupId);
            return students;
        }

        public Student Getstudentbyid(int id)
        {
            Student student = _studentRepository.Getstudentbyid(s=>s.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> GetStudentsByAge(int age)
        {
            List<Student> students = _studentRepository.GetAll(s => s.Age == age);
            return students;
        }

        public List<Student> SearchMethodForStudentsByNameOrSurname(string nameOrSurname)
        {
            List<Student > studentName =_studentRepository.GetAll(s=>s.Name.Trim().ToLower() == nameOrSurname.Trim().ToLower());
            List<Student > studentSurname =_studentRepository.GetAll(s=>s.Surname.Trim().ToLower() ==nameOrSurname.Trim().ToLower());

            if (studentName.Count > 0) return studentName;
            else if (studentSurname.Count > 0) return studentSurname;
            else return null;

        }

        public Student UpdateStudent(int id, Student student)
        {
            Student student1 = Getstudentbyid(id);
            if (student1 == null) return null;
            student1.Name = student.Name;
            student1.Surname=student.Surname;
            student1.Age = student.Age;
            student1.Group = student.Group;
            _studentRepository.UpdateStudent(student1);
            return Getstudentbyid(id);

        }
    }
}
