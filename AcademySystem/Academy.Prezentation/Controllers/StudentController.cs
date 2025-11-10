using Academy.Prezentation.Helpers;
using Domain.Entities;
using Service.Sevices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Prezentation.Controllers
{
    public class StudentController
    {
        StudentSevice _studentSevice = new();
        public void CreateStudent()
        {
        Groups: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
            Name: Helper.PrintColor(ConsoleColor.Blue, "Add student Name:");
                string studentName = Console.ReadLine();
                if (studentName == "")
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Name:");
                    goto Name;
                }
            Surname: Helper.PrintColor(ConsoleColor.Blue, "Add student Surname:");
                string studentSurname = Console.ReadLine();
                if (studentSurname == "")
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Surname:");
                    goto Surname;
                }
            Groupsid: Helper.PrintColor(ConsoleColor.Blue, "Add student Age:");
                string studentAge = Console.ReadLine();
                if (studentAge == "")
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Age:");
                    goto Groupsid;
                }
                int age;
                bool isage = int.TryParse(studentAge, out age);

                if (isage)
                {
                    Student student = new Student { Name = studentName, Surname = studentSurname, Age = age };
                    var result = _studentSevice.CreateStudent(id, student);
                    if (result != null)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Student Id:{student.Id},Student Name:{student.Name},Student SurName:{student.Surname},Student age:{student.Age}");//Student group:{student.group.name}
                    }
                    else
                    {
                        Helper.PrintColor(ConsoleColor.Red, "student Not Fount! ");
                        goto Groups;
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add corret age Type! ");
                    goto Groupsid;
                }
            }
        }

        public void Getstudentbyid()
        {
        Groupsid: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id:");
            string studentId = Console.ReadLine();
            int id;
            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                Student student = _studentSevice.Getstudentbyid(id);
                if (student != null)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Student Id:{student.Id},Student Name:{student.Name},Student Surname:{student.Surname},Student Age:{student.Age}");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "id not Found!");
                    goto Groupsid;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Add corret id Type!");
                goto Groupsid;
            }


        }

        public void DeleteStudent()
        {
        Groupsid: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id:");
            string studentid = Console.ReadLine();
            int id;
            bool isstudentid = int.TryParse(studentid, out id);
            if (isstudentid)
            {
                _studentSevice.DeleteStudent(id);
                Helper.PrintColor(ConsoleColor.Green, "Data Dalete:");
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Add corret group type!");
                goto Groupsid;
            }
        }
    }
}
