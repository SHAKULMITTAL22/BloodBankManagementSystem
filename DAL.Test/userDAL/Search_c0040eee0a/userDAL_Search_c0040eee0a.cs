using NUnit.Framework;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;
using Moq;
using BloodBankManagementSystem.DAL;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    class UserDAL_Search_Test
    {
        private SqliteConnection _connection;
        private string _keywords;
        private UserDAL _userDAL;

        [SetUp]
        public void Setup()
        {
            _keywords = "TestKeyword";
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _userDAL = new UserDAL(_connection.ConnectionString);

            var command = _connection.CreateCommand();
            command.CommandText = "CREATE TABLE tbl_users (user_id STRING, full_name STRING, address STRING)";
            command.ExecuteNonQuery();

            command.CommandText = $"INSERT INTO tbl_users VALUES ('{_keywords}', '{_keywords}', '{_keywords}')";
            command.ExecuteNonQuery();
        }

        [TearDown]
        public void Teardown()
        {
            _connection.Close();
        }

        [Test]
        public void Search_KeywordsMatchExistingUser_ReturnsMatchingRows()
        {
            DataTable result = _userDAL.Search(_keywords);

            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual(_keywords, result.Rows[0]["user_id"]);
            Assert.AreEqual(_keywords, result.Rows[0]["full_name"]);
            Assert.AreEqual(_keywords, result.Rows[0]["address"]);
        }

        [Test]
        public void Search_NoKeywordsMatch_ReturnsNoRows()
        {
            DataTable result = _userDAL.Search("NonMatchingKeyword");

            Assert.AreEqual(0, result.Rows.Count);
        }
    }
}
