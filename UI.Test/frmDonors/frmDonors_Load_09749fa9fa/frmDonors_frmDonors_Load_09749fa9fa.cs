using BloodBankManagementSystem.UI;
using NUnit.Framework;
using NSubstitute;
using System;
using System.Data;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    class frmDonors_frmDonors_Load_09749fa9fa 
    {
        private frmDonors subjectUnderTest;
        private IDataAccessLayer mockDataAccessLayer;
        private string path;

        [SetUp]
        public void SetUp()
        {
            mockDataAccessLayer = Substitute.For<IDataAccessLayer>();
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 10);

            // setup the subjectUnderTest with mock dependency
            subjectUnderTest = new frmDonors(mockDataAccessLayer);
        }

        [Test]
        public void Test_frmDonors_Load_Should_Assign_DataSource_For_dgvDonors()
        {
            DataTable mockDT = new DataTable();
            mockDataAccessLayer.Select().Returns(mockDT);
            
            subjectUnderTest.frmDonors_Load(new object(), new EventArgs()); 

            Assert.AreSame(mockDT, subjectUnderTest.dgvDonors.DataSource);  
        }

        [Test]
        public void Test_frmDonors_Load_Should_Load_Default_Image_Into_PictureBox()
        {
            string expectedImagePath = path + "\\images\\no-image.jpg";

            subjectUnderTest.frmDonors_Load(new object(), new EventArgs()); 

            Assert.IsTrue(subjectUnderTest.pictureBoxProfilePicture.ImageLocation.Contains(expectedImagePath));
        }
    }
}
