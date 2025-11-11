using Academy.Prezentation.Controllers;
using Academy.Prezentation.Helpers;
using Domain.Entities;
using Service.Sevices.Implementations;

namespace Academy.Prezentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();
            StudentController studentController = new();
            Helper.PrintColor(ConsoleColor.Blue, "Select One Option!");
            GetMenus();

            while (true)
            {
            Selectoption: string sellectOption = Console.ReadLine();

                int sellectTrueOption;

                bool isSellectOptions = int.TryParse(sellectOption, out sellectTrueOption);

                if (isSellectOptions)
                {
                    switch (sellectTrueOption)
                    {
                        case (int)Menus.CreateGroup:
                            groupController.CreateGroup();
                            break;
                        case (int)Menus.UpdateGroup:
                            groupController.UpdateGroup();
                            break;
                        case (int)Menus.DeleteGroup:
                            groupController.DaleteGroup();
                            break;
                        case (int)Menus.GetGroupById:
                            groupController.GetGroupById();
                            break;
                        case (int)Menus.GetAllGroupsByTeacher:
                            groupController.GetAllGroupsByTeacher();
                            break;
                        case (int)Menus.GetAllGroupsByRoom:
                            groupController.GetAllGroupsByRoom();
                            break;
                        case (int)Menus.GetAllGroups:
                            groupController.GetAllGroups();
                            break;
                        case (int)Menus.CreateStudent:
                            studentController.CreateStudent();
                            break;
                        case (int)Menus.UpdateStudent:
                            studentController.UpdateStudent();
                            break;
                        case (int)Menus.GetStudentById:
                            studentController.Getstudentbyid();
                            break;
                        case (int)Menus.DeleteStudent:
                            studentController.DeleteStudent();
                            break;
                        case (int)Menus.GetStudentsByAge:
                            studentController.GetStudentsByAge();
                            break;
                        case (int)Menus.GetAllStudentsByGroupId:
                            studentController.GetAllStudentsByGroupId();
                            break;
                        case (int)Menus.SearchMethodForGroupsByName:
                            groupController.SearchMethodForGroupsByName();
                            break;
                        case (int)Menus.SearchMethodForStudentsByNameOrSurname:
                            studentController.SearchMethodForStudentsByNameOrSurname();
                            break;
                    }

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Sellect true option Type!");
                    goto Selectoption;
                }
            }

        }
        private static void GetMenus()
        {
            Helper.PrintColor(ConsoleColor.Yellow, "1-Create Group\n2-Update group\n3-Delete Group\n4-Get group by id\n5-Get all groups by teacher\n6-Get all groups by room\n7-Get all groups\n8-Create Student\n9-Update Student\n10-Get student by id\n11-Delete student\n12-Get students by age\n13-Get all students by group id\n14-Search method for groups by name\n15-Search method for students by name or surname.");
        }
    }
}
