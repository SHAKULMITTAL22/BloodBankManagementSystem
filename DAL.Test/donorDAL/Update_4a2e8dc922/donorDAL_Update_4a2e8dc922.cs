using NUnit.Framework;
using Moq;
using BloodBankManagementSystem.DAL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BloodBankManagementSystem.DAL.Tests
{
    [TestFixture]
    public class donorDAL_Update_4a2e8dc922
    {
        private Mock<SqlConnection> mockDbConnection;
        private donorDAL testDonorDal;
        private donorBLL testDonorBll;

        [SetUp]
        public void Setup()
        {
            this.mockDbConnection = new Mock<SqlConnection>();
            var configuration = new Mock<IConfiguration>();

            this.testDonorDal = new donorDAL(mockDbConnection.Object, configuration.Object);

            this.testDonorBll = new donorBLL
            {
                first_name = "Test",
                last_name = "User",
                email = "test.user@example.com",
                contact = "1234567890",
                gender = "M",
                address = "Test Address",
                blood_group = "O+",
                image_name = "test.jpg",
                added_by = 1
            };
        }

        [Test]
        public void Update_SuccessfulUpdate_ReturnsTrue()
        {
            var mockCommand = new Mock<SqlCommand>();
            mockCommand.Setup(m => m.ExecuteNonQuery()).Returns(1);
            mockDbConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);

            bool result = testDonorDal.Update(testDonorBll);

            Assert.True(result);
        }

        [Test]
        public void Update_UnsuccessfulUpdate_ReturnsFalse()
        {
            var mockCommand = new Mock<SqlCommand>();
            mockCommand.Setup(m => m.ExecuteNonQuery()).Returns(0);
            mockDbConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);

            bool result = testDonorDal.Update(testDonorBll);

            Assert.False(result);
        }
    }
}
