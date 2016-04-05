namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }
        public IView Register(
            string username,
            string password,
            string confirmPassword,
            string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this
                .Data
                .Users
                .GetByUsername(username);

            if (existingUser != null)
            {
                var message = string.Format("A user with username {0} already exists.", username);
                throw new ArgumentException(message);
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            //var hashPassword = HashUtilities.HashPassword(password);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);

            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                var message = string.Format("A user with username {0} does not exist.", username);
                throw new ArgumentException(message);
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }
            this.CurrentUser = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
                throw new ArgumentException("There is no currently logged in user.");

            //if (!this.CurrentUser.IsInRole(Role.Lecturer) && !this.CurrentUser.IsInRole(Role.Student))
            //    throw new DivideByZeroException("The current user is not authorized to perform this operation.");

            var user = this.CurrentUser;
            this.CurrentUser = null;

            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}