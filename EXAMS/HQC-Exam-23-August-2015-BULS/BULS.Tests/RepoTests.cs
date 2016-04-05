
namespace BULS.Tests
{
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepoTests
    {
        private Repository<User> users;

        [TestInitialize]
        public void InitializeRepo()
        {
            this.users = new Repository<User>();
        }

        [TestMethod]
        public void Get_ValidId_Should_Return_Element()
        {
            //Arrange
            var userList = new List<User>()
            {
                new User("Pesho", "112233", Role.Lecturer),
                new User("Gosho", "221133", Role.Student),
            };

            foreach (var user in userList)
            {
                this.users.Add(user);
            }

            //Act
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            //Assert
            Assert.AreEqual(userList[Id - 1], actualUser);
        }

        [TestMethod]
        public void Get_IncvalidId_Should_Return_Default()
        {
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            //Assert
            Assert.AreEqual(default(User), actualUser);
        }

        [TestMethod]
        public void Get_IncvalidId_Shoukd_Return_Default_User()
        {
            //Arrange
            var userList = new List<User>()
            {
                new User("Pesho", "112233", Role.Lecturer),
                new User("Gosho", "221133", Role.Student),
            };

            foreach (var user in userList)
            {
                this.users.Add(user);
            }

            //Act
            int Id = userList.Count + 1;
            var actualUser = this.users.Get(Id);

            //Assert
            Assert.AreEqual(default(User), actualUser);
        }
    }
}
