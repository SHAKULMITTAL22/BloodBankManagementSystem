// Test generated by RoostGPT for test roost-test using AI Type Azure Open AI and AI Model roost-gpt4-32k

using NUnit.Framework;
using BloodBankManagementSystem.UI;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_frmDonors_1ab0055eaf
    {
        private frmDonors _frmDonors;

        [SetUp]
        public void SetUp()
        {
            _frmDonors = new frmDonors();
        }

        [Test]
        public void Test_frmDonors_Constructor_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => new frmDonors());
        }

        [TearDown]
        public void Cleanup()
        {
            _frmDonors = null;
        }
    }
}