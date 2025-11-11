using Academy.Prezentation.Helpers;
using Domain.Entities;
using Service.Sevices.Implementations;
using Service.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy.Prezentation.Controllers
{
    internal class GroupController
    {
        GroupsService _groupsService = new();
        public void CreateGroup()
        {
        Name: Helper.PrintColor(ConsoleColor.Blue, "Add Group Name:");
            string groupName = Console.ReadLine();
            if(string.IsNullOrEmpty(groupName))
            {
                Helper.PrintColor(ConsoleColor.Red, "Add Group Name:");
                goto Name;
            }
        Teacher: Helper.PrintColor(ConsoleColor.Blue, "Add Group Teacher:");
            string groupTeacher = Console.ReadLine();
            if (string.IsNullOrEmpty(groupTeacher))
            {
                Helper.PrintColor(ConsoleColor.Red, "Add Group Teacher:");
                goto Teacher;
            }
        Room: Helper.PrintColor(ConsoleColor.Blue, "Add Group Room");
            string groupRoom = Console.ReadLine();
            if (string.IsNullOrEmpty(groupRoom))
            {
                Helper.PrintColor(ConsoleColor.Red, "Add Group Room:");
                goto Room;
            }
            Groups group = new Groups { Name = groupName, Teacher = groupTeacher, Room = groupRoom };
            var result = _groupsService.CreateGroup(group);
            Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
        }
        public void GetGroupById()
        {
        GroupId: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                Groups group = _groupsService.GetGroupById(id);
                if (group != null)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Id not found");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Add corret id Type!");
                goto GroupId;
            }
        }
        public void GetAllGroups()
        {
            List<Groups> groups = _groupsService.GetAllGroups();
            if (groups != null) {
                foreach (Groups group in groups)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Pleace Creat Group");
            }
        }
        public void DaleteGroup()
        {
        GroupId: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId) {
                _groupsService.DeleteGroup(id);
                Helper.PrintColor(ConsoleColor.Green, "Data Delete");

            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Add corret group type!");
                goto GroupId;
            }

        }
        public void GetAllGroupsByRoom()
        {
            Helper.PrintColor(ConsoleColor.Blue, "Add Group Room");
            string groupName = Console.ReadLine();

            List<Groups> groups=_groupsService.GetAllGroupsByRoom(groupName);
            if (groups.Count !=0) {
                foreach (Groups group in groups) {
                    Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Room not found for search text!");
            }
        }
        public void GetAllGroupsByTeacher()
        {
        SearchText: Helper.PrintColor(ConsoleColor.Blue, "Add Group Teacher");
            string teacherName = Console.ReadLine();

            List<Groups> groups = _groupsService.GetAllGroupsByRoom(teacherName);
            if (groups.Count != 0)
            {
                foreach (Groups group in groups)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Teacher not found for search text!");
                goto SearchText;
            }
        }
        public void UpdateGroup()
        {
        GroupID: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id");
            string groupId = Console.ReadLine();
            if (string.IsNullOrEmpty(groupId))
            {
                Helper.PrintColor(ConsoleColor.Yellow, "Update operation cancelled.");
                return;
            }

            int id;
            bool isGroupID = int.TryParse(groupId, out id);
            if (isGroupID)
            {
                var findGroup = _groupsService.GetGroupById(id);
                if (findGroup != null)
                {
                    Helper.PrintColor(ConsoleColor.Blue, "Add new Group name or skip via current name");
                    string newGroupName = Console.ReadLine();
                    if (newGroupName is null)
                    {
                        newGroupName = findGroup.Name;
                    }

                    Helper.PrintColor(ConsoleColor.Blue, "Add new Teacher or skip via current Teacher");
                    string newTeacher = Console.ReadLine();
                    if (newTeacher is null)
                    {
                        newTeacher = findGroup.Teacher;
                    }

                    Helper.PrintColor(ConsoleColor.Blue, "Add new Room or skip via current Room");
                    string newRoom = Console.ReadLine();
                    if (newRoom is null)
                    {
                        newRoom = findGroup.Room;
                    }

                    Groups groups = new Groups { Name = newGroupName, Teacher = newTeacher, Room = newRoom };

                    var updateGroups = _groupsService.UpdateGroup(id, groups);

                    if (updateGroups == null) { Helper.PrintColor(ConsoleColor.Red, "Library not Updated, please try again"); goto GroupID; }
                    else
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Group ID: {id}, Group name: {groups.Name}, Teacher: {groups.Teacher}, Group Room: {groups.Room} ");
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Not Found ID or doesn't exists any group, try again.");

                    return;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Invalid ID type, try again.");
                goto GroupID;
            }

        }


        public void SearchMethodForGroupsByName()
        {
            Helper.PrintColor(ConsoleColor.Blue, "Add Group Name");
            string groupName = Console.ReadLine();
            List<Groups> groups = _groupsService.GetAllGroupsByRoom(groupName);
            if (groups.Count != 0)
            {
                foreach (Groups group in groups)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group Id:{group.Id},Group Name:{group.Name},Group Teachar:{group.Teacher},Group Room:{group.Room}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Name not found for search text!");
            }
        }


    }
}
