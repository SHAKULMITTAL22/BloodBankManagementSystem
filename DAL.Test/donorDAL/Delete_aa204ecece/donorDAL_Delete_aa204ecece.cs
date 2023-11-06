using System;
using System.Data.SqlClient;
using NUnit.Framework;
using Moq;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class donorDAL_Delete_aa204ecece
    {
        private MockRepository mockRepository;
        private Mock<IDbConnectionFactory> mockDbConnectionFactory;
        private Mock<SqlConnection> mockSqlConnection;
        private Mock<SqlCommand> mockSqlCommand;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockDbConnectionFactory = this.mockRepository.Create<IDbConnectionFactory>();
            this.mockSqlConnection = this.mockRepository.Create<SqlConnection>();
            this.mockSqlCommand = this.mockRepository.Create<SqlCommand>();
        }

        private donorBLL CreateInstance()
        {
            return new donorBLL(
                this.mockDbConnectionFactory.Object);
        }

        [Test]
        public void Delete_StateUnderTest_AreEqual()
        {
            var instance = this.CreateInstance();
            donorBLL d = CreateDonor(); 

            mockDbConnectionFactory.Setup(x => x.CreateConnection()).Returns(mockSqlConnection.Object);

            mockSqlConnection.Setup(x => x.Open());

            mockSqlCommand.Setup(x => x.CommandText).Returns("DELETE FROM tbl_donors WHERE id = @id");
            mockSqlCommand.Setup(x => x.ExecuteNonQuery()).Returns(1);
            mockSqlCommand.Setup(x => x.ExecuteReader()).Returns(new Mock<System.Data.SqlClient.SqlDataReader>().Object);

            mockSqlConnection.Setup(x => x.CreateCommand()).Returns(mockSqlCommand.Object);

            var actualResult = instance.Delete(d);
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void Delete_StateUnderTest_NotEqual()
        {
            var instance = this.CreateInstance();
            donorBLL d = CreateNullDonor(); 

            mockDbConnectionFactory.Setup(x => x.CreateConnection()).Returns(mockSqlConnection.Object);

            mockSqlConnection.Setup(x => x.Open());

            mockSqlCommand.Setup(x => x.CommandText).Returns("DELETE FROM tbl_donors WHERE id = @id");
            mockSqlCommand.Setup(x => x.ExecuteNonQuery()).Returns(0);
            mockSqlCommand.Setup(x => x.ExecuteReader()).Returns(new Mock<System.Data.SqlClient.SqlDataReader>().Object);

            mockSqlConnection.Setup(x => x.CreateCommand()).Returns(mockSqlCommand.Object);

            var actualResult = instance.Delete(d);            
            Assert.IsFalse(actualResult);
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }
    }
}
