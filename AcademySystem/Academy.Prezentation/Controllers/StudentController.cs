using Academy.Prezentation.Helpers;
using Domain.Entities;
using Service.Sevices.Implementations;
using Service.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repostories.Implementations;

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
               
                if (string.IsNullOrEmpty(studentName))
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Name:");
                    goto Name;
                }
                foreach (char item in studentName)
                {
                    if (!char.IsLetter(item))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "The name should consist of only letters:");
                        goto Name;
                    }
                }
                if (studentName.Length < 3)
                {
                    Helper.PrintColor(ConsoleColor.Red, "The name must be at least 3 letters long.");
                    goto Name;
                }
               
            Surname: Helper.PrintColor(ConsoleColor.Blue, "Add student Surname:");
                string studentSurname = Console.ReadLine();
             
                if (string.IsNullOrEmpty(studentSurname))
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Surname:");
                    goto Surname;
                }
                foreach (char item in studentSurname)
                {
                    if (!char.IsLetter(item))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "The SurName should consist of only letters:");
                        goto Surname;
                    }
                }
                if (studentSurname.Length < 3)
                {
                    Helper.PrintColor(ConsoleColor.Red, "The surname must be at least 3 letters long.");
                    goto Surname;
                }
              
            Groupsid: Helper.PrintColor(ConsoleColor.Blue, "Add student Age:");
                string studentAge = Console.ReadLine();
                if (string.IsNullOrEmpty(studentAge))
                {
                    Helper.PrintColor(ConsoleColor.Red, "Add student Age:");
                    goto Groupsid;
                }
                int age;
                bool isage = int.TryParse(studentAge, out age);


                if (isage)
                {
                    if (age >= 17) {
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
                        Helper.PrintColor(ConsoleColor.Red, "Must be over 17 years old. ");
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
                Student student = _studentSevice.Getstudentbyid(id);
                if (student != null) {
                    _studentSevice.DeleteStudent(id);
                    Helper.PrintColor(ConsoleColor.Green, "Data Dalete");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "id not found");
                    return;
                }
                
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
            if (studentNameOrSurname != null)
            {
                var result = _studentSevice.SearchMethodForStudentsByNameOrSurname(studentNameOrSurname);
                if (result != null)
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

        public void UpdateStudent()
        {
        Idget: Helper.PrintColor(ConsoleColor.Blue, "Add Student Id:");
            string studentId = Console.ReadLine();
            if (studentId == null)
            {
                Helper.PrintColor(ConsoleColor.Red, " Enter The Id");
                goto Idget;
            }
            int id;
            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                var findid = _studentSevice.Getstudentbyid(id);
                if (findid != null)
                {
                Namestudent: Helper.PrintColor(ConsoleColor.Blue, "Enter New Name Or Previous Name");
                    string newstudentName = Console.ReadLine();
                    if (string.IsNullOrEmpty(newstudentName))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "add  Name");
                        goto Namestudent;
                    }
                Surnamestudent: Helper.PrintColor(ConsoleColor.Blue, "Enter New Surname Or Previous Surname");
                    string newstudentSurname = Console.ReadLine();
                    if (string.IsNullOrEmpty(newstudentSurname))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "add  Name");
                        goto Surnamestudent;
                    }
                Agestudent: Helper.PrintColor(ConsoleColor.Blue, "Enter New Age Or Previous Age");
                    string newStudentAge = Console.ReadLine();
                    if (string.IsNullOrEmpty(newStudentAge))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "add  Age");
                        goto Agestudent;
                    }
                    int age;
                    bool isnewStudentAge = int.TryParse(newStudentAge, out age);
                    if (isnewStudentAge == false)
                    {
                        Helper.PrintColor(ConsoleColor.Red, "Invalid Age type");
                        goto Agestudent;
                    }
                Groupstudent: Helper.PrintColor(ConsoleColor.Blue, "Enter New  groups id");
                    string newStudentGroup = Console.ReadLine();
                    if (string.IsNullOrEmpty(newStudentGroup))
                    {
                        Helper.PrintColor(ConsoleColor.Red, "add  group id");
                        goto Groupstudent;
                    }
                    int groupId;
                    bool isnewStudentGroup = int.TryParse(newStudentGroup, out groupId);

                    if (isnewStudentGroup == false)
                    {
                        Helper.PrintColor(ConsoleColor.Red, "Invalid ID type");
                        return;
                    }
                    var groupRepo = new GroupsRepository();
                    var newGroup = groupRepo.Get(g => g.Id == groupId);
                    if (newGroup == null)
                    {
                        Helper.PrintColor(ConsoleColor.Red, "Group not found.");
                        goto Groupstudent;
                    }
                    Student student = new Student { Name = newstudentName, Surname = newstudentSurname, Age = age, Group = newGroup };

                    var students = _studentSevice.UpdateStudent(id, student);
                    if (students != null)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"ID: {students.Id},Name: {students.Name},Surname: {students.Surname},Age: {students.Age},Group: {students.Group.Name}");
                    }
                    else
                    {
                        Helper.PrintColor(ConsoleColor.Red, "not found id");
                        return;
                    }

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "not found id");
                    return;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Invalid ID type");
                goto Idget;
            }


        }
    }
}
