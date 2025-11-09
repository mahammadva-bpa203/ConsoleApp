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
    public class GroupsRepository : IRepositoryGroups<Groups>
    {
        public void CreateGroup(Groups data)
        {
            try
            {
                if (data is null) throw new NotFoundExceptation("Data Not Found! ");
                AppDbContext<Groups>.datas.Add(data);                 
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteGroup(Groups data)
        {
            AppDbContext<Groups>.datas.Remove(data);
        }

        public List<Groups> GetAllGroups(Predicate<Groups> predicate=null)
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate):AppDbContext<Groups>.datas;
        }

        public List<Groups> GetAllGroupsByRoom(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;
        }

        public List<Groups> GetAllGroupsByTeacher(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;
        }

        public Groups GetGroupById(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.Find(predicate) : null;
        }

        public void UpdateGroup(Groups data)
        {
            Groups groups=GetGroupById(g=>g.Id==data.Id);
            if (string.IsNullOrEmpty(data.Name))
            {
                groups.Name = data.Name;
            }
            if (string.IsNullOrEmpty(data.Room))
            {
                groups.Room = data.Room;
            }
            if (string.IsNullOrEmpty(data.Teacher))
            {
                groups.Teacher = data.Teacher;
            }

        }
    }
}
