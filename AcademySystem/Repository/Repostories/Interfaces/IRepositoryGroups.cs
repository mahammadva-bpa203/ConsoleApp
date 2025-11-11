using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Repostories.Interfaces
{
    public interface IRepositoryGroups<T> where T : BaseEntity
    {
        void CreateGroup(T data);
        void UpdateGroup(T data);
        void DeleteGroup(T data);
        T GetGroupById(Predicate<T> predicate);
        List<T> GetAllGroupsByTeacher(Predicate<T> predicate);
        List<T> GetAllGroupsByRoom(Predicate<T> predicate);
        List<T> GetAllGroups(Predicate<T> predicate);

        List<T> SearchMethodForGroupsByName(Predicate<T> predicate);
        T Get(Predicate<T> predicate);



    }
}
