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
                if (data is null) throw new NotFoundExceptation("Data Not Found");

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
            
        }

        public List<Student> GetAllStudentsByGroupId(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student Getstudentbyid(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
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
