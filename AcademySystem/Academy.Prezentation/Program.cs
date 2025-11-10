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
                        case 1:
                            groupController.CreateGroup();
                            break;
                        case 2:
                            groupController.UpdateGroup();
                            break;
                        case 3:
                            groupController.DaleteGroup();
                            break;
                        case 4:
                            groupController.GetGroupById();
                            break;
                        case 5:
                            groupController.GetAllGroupsByTeacher();
                            break;
                        case 6:
                            groupController.GetAllGroupsByRoom();
                            break;
                        case 7:
                            groupController.GetAllGroups(); 
                            break;
                        case 8:
                            studentController.CreateStudent();
                            break; 
                        case 10:
                            studentController.Getstudentbyid();
                            break;
                        case 11:
                            studentController.DeleteStudent();
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
