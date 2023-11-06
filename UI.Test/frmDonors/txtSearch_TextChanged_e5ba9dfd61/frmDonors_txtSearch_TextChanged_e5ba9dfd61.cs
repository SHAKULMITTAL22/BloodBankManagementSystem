// Test generated by RoostGPT for test roost-test using AI Type Azure Open AI and AI Model roost-gpt4-32k

using System;
using System.Data;
using NUnit.Framework;
using Moq;
using BloodBankManagementSystem.UI;


namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_txtSearch_TextChanged_e5ba9dfd61
    {
        private Mock<IDAL> _mockDal;
        private frmDonors _form;        
        
        [SetUp]
        public void Setup()
        {
            _mockDal = new Mock<IDAL>();
            _form = new frmDonors(_mockDal.Object);
        }

        [Test]
        public void txtSearch_TextChanged_KeywordsNotNull_ReturnsSearchedData()
        {
            //Arrange
            DataTable dt = new DataTable();
            _mockDal.Setup(dal => dal.Search(It.IsAny<string>())).Returns(dt);

            //Act
            _form.txtSearch.Text = "abc";
            _form.txtSearch_TextChanged(new object(), new EventArgs());

            //Assert
            Assert.AreSame(dt, _form.dgvDonors.DataSource);
        }

        [Test]
        public void txtSearch_TextChanged_KeywordsNull_ReturnsAllData()
        {
            //Arrange
            DataTable dt = new DataTable();
            _mockDal.Setup(dal => dal.Select()).Returns(dt);

            //Act
            _form.txtSearch.Text = null;
            _form.txtSearch_TextChanged(new object(), new EventArgs());

            //Assert
            Assert.AreSame(dt, _form.dgvDonors.DataSource);
        }
    }

    public interface IDAL
    {
        DataTable Search(string keywords);
        DataTable Select();
    }
}