using NUnit.Framework;
using Moq;
using System.Data.SqlClient;
using System.Data;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    public interface IDataBase
    {
        bool LoginCheck(string username, string password);
    }

    public class loginBLL
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    [TestFixture]
    public class loginDAL_loginCheck_b341659581
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDbDataAdapter> _mockDataAdapter;
        private Mock<IDataBase> _database;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockDataAdapter = new Mock<IDbDataAdapter>();
            _database = new Mock<IDataBase>();

            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = new SqlConnection("Data Source=localhost;")
            };
            _mockCommand.Setup(m => m.CreateParameter()).Returns(sqlCommand.CreateParameter());
            _mockConnection.Setup(m => m.CreateCommand()).Returns(_mockCommand.Object);
            _mockDataAdapter.Setup(m => m.SelectCommand).Returns(_mockCommand.Object);
        }

        [Test]
        public void loginCheck_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Rows.Add(dt.NewRow());
            _mockDataAdapter.Setup(m => m.Fill(It.IsAny<DataTable>())).Returns(dt.Rows.Count);
            _database.Setup(d => d.LoginCheck(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act
            bool result = _database.Object.LoginCheck("test", "test");

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void loginCheck_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            DataTable dt = new DataTable();
            _mockDataAdapter.Setup(m => m.Fill(It.IsAny<DataTable>())).Returns(dt.Rows.Count);
            _database.Setup(d => d.LoginCheck(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            // Act
            bool result = _database.Object.LoginCheck("invalid", "invalid");

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
