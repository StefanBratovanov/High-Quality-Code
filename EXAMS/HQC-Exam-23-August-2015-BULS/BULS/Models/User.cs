
namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private const string UserInvalidMessage = "The username must be at least 5 symbols long.";
        private const string PasswordInvalidMessage = "The password must be at least 6 symbols long.";

        private string username;
        private string password;

        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string UserName
        {
            get { return this.username; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(UserInvalidMessage);
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException(UserInvalidMessage);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(PasswordInvalidMessage);
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException(PasswordInvalidMessage);
                }

                var hashPassword = HashUtilities.HashPassword(value);

                this.password = hashPassword;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }

        public void EnrollInCourse(Course course)
        {
            this.Courses.Add(course);
        }
    }
}
