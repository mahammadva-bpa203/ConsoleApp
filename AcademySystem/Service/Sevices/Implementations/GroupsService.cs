using Domain.Entities;
using Repository.Repostories.Implementations;
using Service.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Sevices.Implementations
{
    public class GroupsService : IGroupsService
    {
        private int _count=1;
        private GroupsRepository _groupsRepository;
        public GroupsService()
        {
            _groupsRepository=new GroupsRepository();
        }

        public Groups CreateGroup(Groups group)
        {
            group.Id = _count;
            _groupsRepository.CreateGroup(group);
            _count++;
            return group;

        }

        public void DeleteGroup(int id)
        {
            Groups groups= GetGroupById(id);
            _groupsRepository.DeleteGroup(groups);
        }

        public List<Groups> GetAllGroups()
        {
            return _groupsRepository.GetAllGroups();
        }

        public List<Groups> GetAllGroupsByRoom(string room)
        {
            return _groupsRepository.GetAllGroups(g=>g.Room.Trim().ToLower() == room.Trim().ToLower());
        }

        public List<Groups> GetAllGroupsByTeacher(string teacher)
        {
            return _groupsRepository.GetAllGroups(g => g.Teacher.Trim().ToLower() == teacher.Trim().ToLower());
        }

        public Groups GetGroupById(int id)
        {
            Groups group = _groupsRepository.GetGroupById(g => g.Id == id);

            if (group is null) return null;

            return group;
        }

        public List<Groups> SearchMethodForGroupsByName(string name)
        {
            return _groupsRepository.GetAllGroups(g => g.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Groups UpdateGroup(int id, Groups group)
        {
            Groups groups= GetGroupById(id);
            if (groups is null) return null;
            groups.Id = id;
            groups.Name = groups.Name;
            groups.Teacher = groups.Teacher;
            groups.Room = groups.Room;

            _groupsRepository.UpdateGroup(groups);
            return GetGroupById(id);
        }
    }
}
