// Test regenerated 

using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BloodBankManagementSystem.UI.Tests
{
    [TestFixture]
    public class PictureBoxCloseClickTests
    {
        private Mock<ISampleForm> _mockForm;
        private SampleForm _sampleForm;

        [SetUp]
        public void SetUp()
        {
            _mockForm = new Mock<ISampleForm>();
            _sampleForm = new SampleForm(_mockForm.Object);
        }

        [Test]
        public void PictureBoxCloseClick_ShouldHideForm_WhenClicked()
        {
            // Arrange
            var sender = new object();
            var eventArgs = new EventArgs();

            // Act
            _sampleForm.pictureBoxClose_Click(sender, eventArgs);

            // Assert
            _mockForm.Verify(form => form.Hide(), Times.Once);
        }

        [Test]
        [TestCaseSource(nameof(GetDifferentEventArgs))]
        public void PictureBoxCloseClick_ShouldHideForm_WhenClickedWithDifferentEventArgs(EventArgs eventArgs)
        {
            // Arrange
            var sender = new object();

            // Act
            _sampleForm.pictureBoxClose_Click(sender, eventArgs);

            // Assert
            _mockForm.Verify(form => form.Hide(), Times.Once);
        }

        public static IEnumerable<TestCaseData> GetDifferentEventArgs()
        {
            yield return new TestCaseData(new EventArgs());
            yield return new TestCaseData(new MouseEventArgs(MouseButtons.None, 0 ,0 ,0 ,0));
        }

        [TearDown]
        public void TearDown()
        {
            _mockForm = null;
            _sampleForm = null;
        }
    }
}
