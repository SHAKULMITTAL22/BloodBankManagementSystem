using NUnit.Framework;
using Moq;
using System.Data;
using System.Data.Common;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class userDAL_Select_865ccf40d4
    {
        private MockRepository mockRepository;
        private Mock<DbConnection> mockDbConnection;
        private Mock<DbCommand> mockDbCommand;
        private Mock<DbDataAdapter> mockDataAdapter;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDbConnection = this.mockRepository.Create<DbConnection>();
            this.mockDbCommand = this.mockRepository.Create<DbCommand>();
            this.mockDataAdapter = this.mockRepository.Create<DbDataAdapter>();

            this.mockDbConnection.SetupGet(x => x.ConnectionString).Returns("FakeConnectionString");
            this.mockDbConnection.Setup(x => x.CreateCommand()).Returns(this.mockDbCommand.Object);
            this.mockDbCommand.SetupProperty(x => x.CommandText);
            this.mockDbCommand.SetupProperty(x => x.Connection);
            this.mockDataAdapter.Setup(x => x.Fill(It.IsAny<DataTable>())).Returns(0);
        }

        [Test]
        public void Select_ValidCall()
        {
            // Arrange
            DataTable expectedResult = new DataTable();
            this.mockDbCommand.Setup(x => x.ExecuteReader()).Returns(expectedResult.CreateDataReader());

            // Act
            userDAL userDAL = new userDAL(this.mockDbConnection.Object);
            DataTable result = userDAL.Select();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Select_ConnectionException()
        {
            // Arrange
            this.mockDbConnection.Setup(x => x.Open()).Throws<Exception>();

            // Act and Assert
            userDAL userDAL = new userDAL(this.mockDbConnection.Object);
            Assert.Throws<Exception>(() => userDAL.Select());
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }
    }
}
