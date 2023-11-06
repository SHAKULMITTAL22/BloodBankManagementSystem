using BloodBankManagementSystem.DAL;
using Moq;
using NUnit.Framework;
using System.Data;
using System.Data.Common;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class UserDAL_GetIDFromUsername_91a67b1371
    {
        private Mock<DbConnection> _mockConnection;
        private Mock<DbCommand> _mockCommand;
        private Mock<DbProviderFactory> _mockFactory;
        private userDAL _userDal;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<DbConnection>() { CallBase = true };
            _mockCommand = new Mock<DbCommand>();

            _mockConnection.Setup(cmd => cmd.CreateCommand()).Returns(_mockCommand.Object);
            _userDal = new userDAL(_mockConnection.Object, "System.Data.SqlClient");
        }

        [Test]
        public void GetIDFromUsername_ReturnsExpectedId_WhenUsernameExists()
        {
            // Arrange
            var dataReader = new DataTableReader(new DataTable("Result") 
            {
                Columns = { new DataColumn("user_id", typeof(int)) },
                Rows = { new object[] { 123 } }
            });

            _mockCommand.Setup(cmd => cmd.ExecuteReader())
                .Returns(dataReader);

            // Act
            var result = _userDal.GetIDFromUsername("bob");

            // Assert
            Assert.AreEqual(123, result);
        }

        [Test]
        public void GetIDFromUsername_ReturnsMinusOne_WhenUsernameDoesNotExist()
        {
            // Arrange
            var dataReader = new DataTableReader(new DataTable("Result") 
            {
                Columns = { new DataColumn("user_id", typeof(int)) }
            });

            _mockCommand.Setup(cmd => cmd.ExecuteReader())
                .Returns(dataReader);

            // Act
            var result = _userDal.GetIDFromUsername("alice");

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
