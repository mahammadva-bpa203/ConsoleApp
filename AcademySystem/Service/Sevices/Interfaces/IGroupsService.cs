using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Sevices.Interfaces
{
    public interface IGroupsService
    {
        Groups CreateGroup(Groups group);
        Groups UpdateGroup(int id , Groups group);
        void DeleteGroup(int id);
        Groups GetGroupById(int id);
        List<Groups> GetAllGroupsByTeacher(string teacher);
        List<Groups> GetAllGroupsByRoom(string room);

        List<Groups> GetAllGroups();
        List<Groups> SearchMethodForGroupsByName(string name);



    }
}
