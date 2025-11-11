using Domain.Entities;
using Repository.Data;
using Repository.Excemtions;
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
            try
            {
                if (data == null) throw new NotFoundExceptation("Data Not Found");

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteStudent(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }
        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }


        public List<Student> GetAllStudentsByGroupId(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public Student Getstudentbyid(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetStudentsByAge(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public List<Student> SearchMethodForStudentsByNameOrSurname(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void UpdateStudent(Student data)
        {
            Student student=Get(s=>s.Id==data.Id);
            if(student==null) return;

            if (!string.IsNullOrEmpty(student.Name)) { 
                student.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(student.Surname)) { 
                student .Surname = data.Surname;
            }
            if (data.Age>0) { 
                student.Age = data.Age;
            }
            if (data.Group != null)
            {
                student.Group = data.Group;
            }
        }
    }
}
