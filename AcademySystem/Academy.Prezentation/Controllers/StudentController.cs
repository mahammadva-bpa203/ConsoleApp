using Academy.Prezentation.Helpers;
using Domain.Entities;
using Service.Sevices.Implementations;
using Service.Sevices.Interfaces;
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
                if (age >= 0)
                {
                    if (isage)
                    {
                        studentName = char.ToUpper(studentName[0]) + studentName.Substring(1).ToLower();
                        studentSurname = char.ToUpper(studentSurname[0]) + studentSurname.Substring(1).ToLower();

                        Student student = new Student { Name = studentName, Surname = studentSurname, Age = age };
                        var result = _studentSevice.CreateStudent(id, student);
                        if (result != null)
                        {
                            Helper.PrintColor(ConsoleColor.Green, $"Student Id:{student.Id},Student Name:{student.Name},Student SurName:{student.Surname},Student age:{student.Age},student Group:{result.Group.Name}");
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
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "The number cannot be less than zero.");
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

        public void GetStudentsByAge()
        {
        Age: Helper.PrintColor(ConsoleColor.Blue, "Add Student age");
            string groupAge = Console.ReadLine();
            int age;
            bool isGroupAge = int.TryParse(groupAge, out age);
            if (isGroupAge)
            {
                var student = _studentSevice.GetStudentsByAge(age);
                if (student != null)
                {
                    foreach (var item in student)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Student Id:{item.Id},Student Name:{item.Name},Student SurName:{item.Surname},Student age:{item.Age},student Group:{item.Group.Name}");
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Blue, "not Found Age");
                    return;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Blue, "Invalid ID type");
                goto Age;
            }

        }

        public void GetAllStudentsByGroupId()
        {
        Groupsid: Helper.PrintColor(ConsoleColor.Blue, "Add Student group id");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                var student = _studentSevice.GetAllStudentsByGroupId(id);
                if (student != null)
                {
                    foreach (var item in student)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Student Id:{item.Id},Student Name:{item.Name},Student SurName:{item.Surname},Student age:{item.Age},student Group:{item.Group.Name}");
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Id not Found");
                    return;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Invalid ID type");
                goto Groupsid;
            }
        }

        public void SearchMethodForStudentsByNameOrSurname()
        {
        Name: Helper.PrintColor(ConsoleColor.Blue, "Add Student Name or SurName");
            string studentNameOrSurname = Console.ReadLine();
            if (studentNameOrSurname != null) { 
                var result =_studentSevice.SearchMethodForStudentsByNameOrSurname(studentNameOrSurname);
                if(result != null)
                {
                    foreach (var item in result)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Student Id:{item.Id},Student Name:{item.Name},Student SurName:{item.Surname},Student age:{item.Age},student Group:{item.Group.Name}");
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "not Found");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Name or Surname can't be empty");
                goto Name;
            }
        }
    }
}
