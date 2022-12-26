using System;
using Xunit;
using CRUDAPIProject.Model;
using CRUDAPIProject.Repository;
using Moq;
using System.Collections.Generic;
using CRUDAPIProject.Controllers;
using System.Linq;
namespace TestCRUDAPI
{
    public class UnitTestController
    {
        #region Property  
        //public Mock<IUser> mock = new Mock<IUser>();
        #endregion
        private readonly Mock<IUser> mock;
        public UnitTestController()
        {
            mock = new Mock<IUser>();
        }
        [Fact]
        public  void GetUserbyId()
        {
           
            //arrange
            var userList = GetUsersData();
            mock.Setup(x => x.GetUser(2))
                .Returns(userList[1]);
            var userController = new UserController(mock.Object);
            //act
            var userResult = userController.Get(2);


            //assert
            Assert.NotNull(userResult);
            Assert.Equal(userList[1].Id, userResult.Id);
            Assert.True(userList[1].Id == userResult.Id);
            Assert.Equal(userList[1].Name, userResult.Name);
            Assert.True(userList[1].Name == userResult.Name);
            Assert.Equal(userList[1].Username, userResult.Username);
            Assert.True(userList[1].Username == userResult.Username);
            Assert.Equal(userList[1].Email, userResult.Email);
            Assert.True(userList[1].Email == userResult.Email);

        }
        [Fact]
        public  void GetUserDetails()
        {
            //arrange
            var userList = GetUsersData();
            mock.Setup(x => x.GetUsers())
                .Returns(userList);
            var userController = new UserController(mock.Object);
            //act
            var userResult = userController.GetUsers();
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(GetUsersData().Count(), userResult.Count());
            Assert.Equal(GetUsersData().ToString(), userResult.ToString());
            Assert.True(userList.Equals(userResult));
        }
        [Theory]
        [InlineData("Bret")]
        public void CheckUserExistOrNotByUserName(string userName)
        {
            //arrange
            var userList = GetUsersData();
            mock.Setup(x => x.GetUsers())
                .Returns(userList);
            var userController = new UserController(mock.Object);
            //act
            var userResult = userController.GetUsers();
            var expectedUserName = userResult.ToList()[0].Username;
            //assert
            Assert.Equal(userName, expectedUserName);
        }
        public List<Users> GetUsersData()
        {
            List<Users> usersData = new List<Users>
         {
            new Users
            {
                Id = 1,
                Name = "Leanne Graham",
                Username = "Bret",
                Email = "Sincere@april.biz",
                Phone = "1-770-736-8031 x56442",
                Website="hildegard.org",

            },
             new Users
            {
                Id = 2,
                Name = "Ervin Howell",
                Username = "Antonette",
                Email = "Shanna@melissa.tv",
                Phone = "010-692-6593 x09125",
                Website="anastasia.net",
            }
          };
          return usersData;
        }

    }
}

