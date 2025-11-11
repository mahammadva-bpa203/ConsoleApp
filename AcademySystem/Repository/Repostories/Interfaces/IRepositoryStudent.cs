using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Interfaces
{
    public interface IRepositoryStudent<T> where T : BaseEntity
    {
        void CreateStudent(T data);
        void UpdateStudent(T data);
        T Getstudentbyid(Predicate<T> predicate);
        void DeleteStudent(T data);
       
        List<T> GetAllStudentsByGroupId(Predicate<T> predicate);

        List<T> GetStudentsByAge(Predicate<T> predicate);

        List<T> SearchMethodForStudentsByNameOrSurname(Predicate<T> predicate);
        T Get(Predicate<T> predicate);

    }
}
