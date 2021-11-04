using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_InterfaceGraphique.Classes
{
    public class LoginController
    {
        public static User ActiveUser;

        public static bool TryLogin(int userId, string password, bool isStudent)
        {
            if (isStudent)
                return TryLoginStudent(userId, password);
            else
                return TryLoginTeacher(userId, password);
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
