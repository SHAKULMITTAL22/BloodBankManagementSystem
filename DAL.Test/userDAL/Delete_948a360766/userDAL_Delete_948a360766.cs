// Test generated by RoostGPT for test roost-test using AI Type Azure Open AI and AI Model roost-gpt4-32k

using NUnit.Framework;
using System.Data.SqlClient;
using System;
using BloodBankManagementSystem.BLL;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class userDAL_Delete_948a360766 
    {
        private UserDAL _userDAL;

        [SetUp]
        public void Setup() 
        {
            _userDAL = new UserDAL();
        }

        [Test]
        public void Delete_WhenCalledWithExistingUser_ShouldReturnTrue()
        {
            userBLL testUser = new userBLL 
            { 
                // TODO: Insert the id of an existing user 
                user_id = "existing-user-id"  
            };

            bool result = _userDAL.Delete(testUser);

            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_WhenCalledWithNonExistingUser_ShouldReturnFalse()
        {
            userBLL testUser = new userBLL 
            { 
                // TODO: Insert the id of a non-existing user
                user_id = "non-existing-user-id" 
            };

            bool result = _userDAL.Delete(testUser);

            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_WhenCalledWithNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _userDAL.Delete(null));
        }
    }
}