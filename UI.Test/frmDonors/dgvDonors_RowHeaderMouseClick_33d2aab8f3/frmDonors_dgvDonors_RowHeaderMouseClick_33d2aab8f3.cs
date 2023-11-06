using NUnit.Framework;
using System.Windows.Forms;
using BloodBankManagementSystem.UI;
using Moq;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_dgvDonors_RowHeaderMouseClick_33d2aab8f3
    {
        private frmDonors sut;

        [SetUp]
        public void SetUp()
        {
            sut = new frmDonors();
        }

        [Test]
        public void DgvDonors_RowHeaderMouseClick_WithValidRowIndex_PopulatesTextboxes()
        {
            // Arrange
            var mockDgvDonors = new Mock<DataGridView>();
            var args = new DataGridViewCellMouseEventArgs(0, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

            // Simulated row data
            var rowData = new object[] { "1", "John", "Doe", "jdoe@example.com", "1234567890", "Male", "123 Main St", "A+", "imageName" };

            sut.dgvDonors.Rows.Add(rowData);

            // Act
            sut.dgvDonors_RowHeaderMouseClick(mockDgvDonors.Object, args);

            // Assert
            Assert.AreEqual("1", sut.txtDonorID.Text);
            Assert.AreEqual("John", sut.txtFirstName.Text);
            Assert.AreEqual("Doe", sut.txtLastName.Text);
            Assert.AreEqual("jdoe@example.com", sut.txtEmail.Text);
            Assert.AreEqual("1234567890", sut.txtContact.Text);
            Assert.AreEqual("Male", sut.cmbGender.Text);
            Assert.AreEqual("123 Main St", sut.txtAddress.Text);
            Assert.AreEqual("A+", sut.cmbBloodGroup.Text);
        }

        [Test]
        public void DgvDonors_RowHeaderMouseClick_WithEmptyRow_DoesNotPopulateTextBoxes()
        {
            // Arrange
            var mockDgvDonors = new Mock<DataGridView>();
            var args = new DataGridViewCellMouseEventArgs(0, 1, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)); // Event with invalid row index

            // Act
            sut.dgvDonors_RowHeaderMouseClick(mockDgvDonors.Object, args);

            // Assert
            Assert.AreEqual("", sut.txtDonorID.Text);
            Assert.AreEqual("", sut.txtFirstName.Text);
            Assert.AreEqual("", sut.txtLastName.Text);
            Assert.AreEqual("", sut.txtEmail.Text);
            Assert.AreEqual("", sut.txtContact.Text);
            Assert.AreEqual("", sut.cmbGender.Text);
            Assert.AreEqual("", sut.txtAddress.Text);
            Assert.AreEqual("", sut.cmbBloodGroup.Text);
        }
    }
}
