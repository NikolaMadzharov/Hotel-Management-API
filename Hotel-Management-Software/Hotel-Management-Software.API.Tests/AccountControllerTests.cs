namespace Hotel_Management_Software.API.Tests;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.Controllers;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Mvc;

public class AccountControllerTests
{
    private Mock<IUserService> _userService;

    [SetUp]
    public void Setup()
    {
        _userService = new Mock<IUserService>();
    }

    [Test]
    public async Task RegisterWithValidDataShouldReturnOk()
    {
        // Arrange
        var fixture = new Fixture();

        fixture.Customize(new AutoMoqCustomization());

        var userToAddDTO = fixture.Create<UserToAddDTO>();

        _userService.Setup(m => m.RegisterAsync(userToAddDTO)).ReturnsAsync(true);

        var controller = new AccountController(_userService.Object);

        // Act

        IActionResult actionResult = await controller.Register(userToAddDTO);

        var objectResult = actionResult as OkObjectResult;

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(objectResult!.Value, Is.Not.Null);
        });
    }

    [Test]
    public async Task RegisterWithInvalidDataShouldReturnBadRquest()
    {
        // Arrange
        var fixture = new Fixture();

        fixture.Customize(new AutoMoqCustomization());

        var userToAddDTO = fixture.Create<UserToAddDTO>();

        _userService.Setup(m => m.RegisterAsync(userToAddDTO)).ReturnsAsync(false);

        var controller = new AccountController(_userService.Object);

        // Act

        IActionResult actionResult = await controller.Register(userToAddDTO);

        var objectResult = actionResult as BadRequestObjectResult;

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(objectResult!.Value, Is.Not.Null);
        });
    }

    [Test]
    public async Task LoginWithValidDataReturnsOk()
    {
        // Arrange

        var fixture = new Fixture();

        var userLoginDto = fixture.Create<UserLoginDTO>();

        _userService.Setup(m => m.LoginAsync(userLoginDto)).ReturnsUsingFixture(fixture);

        var controller = new AccountController(_userService.Object);

        // Act

        IActionResult actionResult = await controller.Login(userLoginDto);

        var objectResult = actionResult as OkObjectResult;

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(objectResult!.Value, Is.Not.Null);
        });
    }

    [Test]
    public async Task LoginWithInvalidDataReturnsBadRequest()
    {
        // Arrange

        var fixture = new Fixture();

        var userLoginDto = fixture.Create<UserLoginDTO>();

        _userService.Setup(m => m.LoginAsync(userLoginDto))!.ReturnsAsync((string?)null);

        var controller = new AccountController(_userService.Object);

        // Act

        IActionResult actionResult = await controller.Login(userLoginDto);

        var objectResult = actionResult as BadRequestObjectResult;

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(objectResult!.Value, Is.Not.Null);
        });
    }

    [Test]
    public async Task PasswordResetVithValidDataReturnsOk()
    {
        // Arrange

        var fixture = new Fixture();

        var userPasswordResetDto = fixture.Create<UserPasswordResetDTO>();

        var controller = new AccountController(_userService.Object);

        // Act

        IActionResult actionResult = await controller.PasswordReset(userPasswordResetDto);

        Assert.Multiple(() =>
        {
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult, Is.InstanceOf<OkResult>());
        });
    }
}
