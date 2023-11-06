using NUnit.Framework;
using System.Data;
using BloodBankManagementSystem.DAL;
using Moq;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class donorDAL_countDonors_db91ac2f4d
    {
        private Mock<IDbConnection> _connectionMock;
        private Mock<IDbCommand> _commandMock;
        private Mock<IDataAdapter> _dataAdapterMock;
        private Mock<DataTable> _dataTableMock;

        [SetUp]
        public void Setup()
        {
            _connectionMock = new Mock<IDbConnection>();
            _commandMock = new Mock<IDbCommand>();
            _dataAdapterMock = new Mock<IDataAdapter>();
            _dataTableMock = new Mock<DataTable>();
        }

        [Test]
        public void countDonors_ReturnsCorrectNumberOfDonors_GivenValidBloodGroup()
        {
            // Arrange
            var bloodGroup = "A+";
            var sql = $"SELECT * FROM tbl_donors WHERE blood_group = '{bloodGroup}'";

            _dataTableMock.Setup(m => m.Rows.Count).Returns(5);
            _dataAdapterMock.Setup(m => m.Fill(It.IsAny<DataTable>())).Returns(_dataTableMock.Object.Rows.Count);
            _commandMock.Setup(m => m.CommandText).Returns(sql);
            _connectionMock.Setup(m => m.CreateCommand()).Returns(_commandMock.Object);

            var sut = new BloodBankDAL(_connectionMock.Object, _dataAdapterMock.Object);

            // Act
            var result = sut.countDonors(bloodGroup);

            // Assert
            Assert.AreEqual("5", result);
        }

        [Test]
        public void countDonors_ReturnsZero_GivenInvalidBloodGroup()
        {
            // Arrange
            var bloodGroup = "Z-";
            var sql = $"SELECT * FROM tbl_donors WHERE blood_group = '{bloodGroup}'";

            _dataTableMock.Setup(m => m.Rows.Count).Returns(0);
            _dataAdapterMock.Setup(m => m.Fill(It.IsAny<DataTable>())).Returns(_dataTableMock.Object.Rows.Count);
            _commandMock.Setup(m => m.CommandText).Returns(sql);
            _connectionMock.Setup(m => m.CreateCommand()).Returns(_commandMock.Object);

            var sut = new BloodBankDAL(_connectionMock.Object, _dataAdapterMock.Object);

            // Act
            var result = sut.countDonors(bloodGroup);

            // Assert
            Assert.AreEqual("0", result);
        }
    }
}
