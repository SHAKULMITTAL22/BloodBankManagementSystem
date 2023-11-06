using BloodBankManagementSystem.UI;
using NUnit.Framework;
using Moq;
using System;

namespace BloodBankManagementSystem.UI.Tests
{
    [TestFixture]
    public class frmDonors_btnClear_Click_7117c2d6bc_Test
    {
        frmDonors _frmDonors;
        Mock<EventArgs> _eventArgsMock;

        [SetUp]
        public void Setup()
        {
            _frmDonors = new frmDonors();
            _eventArgsMock = new Mock<EventArgs>();
        }

        [Test]
        public void Test_Clear_Click_Calls_Clear_Method() 
        {
            bool isClearMethodCalled = false;

            _frmDonors.Clear = () => isClearMethodCalled = true;

            _frmDonors.btnClear_Click(new Object(), _eventArgsMock.Object);

            Assert.True(isClearMethodCalled);
        }

        [Test]
        public void Test_Clear_Click_Not_Throw_Exception_When_Args_Null()
        {
            Assert.DoesNotThrow(() => _frmDonors.btnClear_Click(new Object(), null));
        }

        [TearDown]
        public void TearDown()
        {
            _frmDonors = null;
            _eventArgsMock = null;
        }
    }
}
