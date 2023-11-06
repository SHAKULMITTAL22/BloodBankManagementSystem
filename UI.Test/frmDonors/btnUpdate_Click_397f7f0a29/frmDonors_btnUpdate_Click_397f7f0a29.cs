using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;

[TestFixture]
public class DonorControllerTests
{
    private Mock<IDonorDataAccessLayer> _dal;
    private Mock<IUserDataAccessLayer> _udal;
    private Mock<ILogger<DonorController>> _logger;
    private DonorController _donorController;

    private Donor _donor;
    private User _loggedInUser;

    [SetUp]
    public void Setup()
    {
        _dal = new Mock<IDonorDataAccessLayer>();
        _udal = new Mock<IUserDataAccessLayer>();
        _logger = new Mock<ILogger<DonorController>>();

        _donorController = new DonorController(_dal.Object, _udal.Object, _logger.Object);

        _donor = new Donor
        {
            // Fill Donor Model Property
        };

        _loggedInUser = new User
        {
            name = "Test",
            email = "test@example.com"
        };
    }

    [Test]
    public void UpdateDonor_ValidInput_ReturnsTrue()
    {
        var result = _donorController.UpdateDonor(_donor, "", "", _loggedInUser, "", _dal, _udal);

        Assert.That(result, Is.True);
    }

    [Test]
    public void UpdateDonor_WhenExceptionThrown_ReturnsFalse()
    {
        string sourcePath= "";
        string destinationPath = "";
        string rowHeaderImage = "";

        _udal.Setup(x => x.GetIDFromUsername(It.IsAny<string>())).Throws(new Exception());

        var result = _donorController.UpdateDonor(_donor, "", "", _loggedInUser, "", _dal, _udal);

        Assert.That(result, Is.False);
    }
}
