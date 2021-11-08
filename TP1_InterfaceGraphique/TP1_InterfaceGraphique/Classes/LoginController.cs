using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_InterfaceGraphique.Windows;

namespace TP1_InterfaceGraphique.Classes
{
    public class LoginController
    {
        public static User ActiveUser;

        public static bool TryLogin(string usernameInput, string password, bool isStudent)
        {
            if(usernameInput == "admin" && password == "admin")
            {
                var adminUser = new Admin();
                adminUser.Id = 0000;
                adminUser.FirstName = "admin";
                adminUser.LastName = "admin";
                adminUser.Password = "admin";
                ActiveUser = adminUser;
                return true;
            }

            int userId;
            if (!Int32.TryParse(usernameInput, out userId))
            {
                return false;
            }

            if (isStudent)
                return TryLoginStudent(userId, password);
            else
                return TryLoginTeacher(userId, password);
        }

        public static void Disconnect()
        {
            ActiveUser = null;
            var loginWindow = new LogIn();
            loginWindow.Show();
        }

        private static bool TryLoginStudent(int userId, string password)
        {
            var students = App.Current.Students;

            Student student = null;

            if (students.TryGetValue(userId, out student))
            {
                if (AreCredentialsValid(student, password))
                {
                    ActiveUser = student;
                    return true;
                }
            }

            return false;
        }

        private static bool TryLoginTeacher(int userId, string password)
        {
            var teachers = App.Current.Teachers;

            Teacher teacher = null;

            if (teachers.TryGetValue(userId, out teacher))
            {
                if (AreCredentialsValid(teacher, password))
                {
                    ActiveUser = teacher;
                    return true;
                }
            }

            return false;
        }

        private static bool AreCredentialsValid(User user, string password)
        {
            return user.Password == password;
        }
    }
}
