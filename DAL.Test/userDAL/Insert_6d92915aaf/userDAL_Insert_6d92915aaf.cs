using NUnit.Framework;
using Moq;
using System.Data.SqlClient;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    class UserDAL_Insert_6d92915aaf
    {
        Mock<SqlConnection> mockSqlConnection;
        Mock<SqlCommand> mockSqlCommand;

        [SetUp]
        public void Setup()
        {
            mockSqlConnection = new Mock<SqlConnection>();
            mockSqlCommand = new Mock<SqlCommand>();
            mockSqlCommand.SetupAllProperties();

            mockSqlConnection.Setup(x => x.Open());

            mockSqlCommand.Setup(x => x.ExecuteNonQuery()).Returns(1);
        }

        [Test]
        public void Insert_GivenValidUser_ReturnsTrue()
        {
            userBLL testUser = new userBLL
            {
                username = "TestUser",
                email = "Test@mail.com",
                password = "Test123",
                full_name = "Test User",
                contact = "12345678",
                address = "Test Street",
                added_date = DateTime.Now,
                image_name = "Test.jpg"
            };

            bool result = new UserDAL().Insert(testUser);

            Assert.IsTrue(result);
        }

        [Test]
        public void Insert_GivenInvalidUser_ReturnsFalse()
        {
            userBLL testUser = null;

            bool result = new UserDAL().Insert(testUser);

            Assert.IsFalse(result);
        }

        [Test]
        public void Insert_GivenExecutionError_ReturnsFalse()
        {
            userBLL testUser = new userBLL();
            
            mockSqlCommand.Setup(x => x.ExecuteNonQuery()).Throws(new Exception());

            bool result = new UserDAL().Insert(testUser);

            Assert.IsFalse(result);
        }
    }
}
