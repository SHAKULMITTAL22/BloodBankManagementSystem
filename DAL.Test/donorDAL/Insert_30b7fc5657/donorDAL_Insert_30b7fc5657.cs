// Regenerated Test Case:

using NUnit.Framework;
using BloodBankManagementSystem.DAL;
using System.Data.SqlClient;
using BloodBankManagementSystem.BLL;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class DonorDAL_Insert_30b7fc5657
    {
        private string myconnstrng = YourConnectionString; // TODO: Change to your connection string

        [Test]
        public void Insert_NewDonor_ReturnsTrue()
        {
            // Arrange
            donorBLL newDonor = new donorBLL()
            {
                first_name = "John",
                last_name = "Doe",
                email = "johndoe@gmail.com",
                contact = "02301283819",
                gender = "Male",
                address = "123 Lane, City, Country",
                blood_group = "A+",
                added_date = DateTime.Now,
                image_name = "john_doe.jpg",
                added_by = 1
            };

            donorDAL donorDalObj = new donorDAL(myconnstrng);

            // Act
            bool result = donorDalObj.Insert(newDonor);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Insert_ExistingDonor_ReturnsFalse()
        {
            // Arrange
            donorBLL existingDonor = new donorBLL()
            {
                first_name = "Existing",
                last_name = "Donor",
                email = "donorexists@gmail.com",
                contact = "0567892134",
                gender = "Female",
                address = "789 Lane, City, Country",
                blood_group = "O-",
                added_date = DateTime.Now,
                image_name = "existing_donor.jpg",
                added_by = 2
            };

            donorDAL donorDalObj = new donorDAL(myconnstrng);

            // Act: Call Insert twice - first might succeed (if this unique donor did not exist previously), but second must fail
            donorDalObj.Insert(existingDonor);
            bool result = donorDalObj.Insert(existingDonor);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
