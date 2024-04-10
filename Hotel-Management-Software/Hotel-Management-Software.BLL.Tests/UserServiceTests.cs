namespace Hotel_Management_Software.BLL.Tests;

using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Image;
using Hotel_Management_Software.DTO.User;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;

public class UserServiceTests
{
    private IMapper _mapper;
    private Mock<IEmailService> _emailService;
    private Mock<SignInManager<ApplicationUser>> _signInManager;
    private Mock<UserManager<ApplicationUser>> _userManager;
    private Mock<IUserRepository> _userRepository;
    private Mock<IConfiguration> _configuration;
    private Mock<IFileStorageService> _storageService;

    [SetUp]
    public void Setup()
    {
        // Seting up dependencies.

        // Real mapper config.
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new ImageProfile());
        }).CreateMapper();

        // Mocked dependencies.
        _emailService = new Mock<IEmailService>();
        _userManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);
        _signInManager = new Mock<SignInManager<ApplicationUser>>(_userManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                null!,
                Mock.Of<IAuthenticationSchemeProvider>());
        _configuration = new Mock<IConfiguration>();
        _userRepository = new Mock<IUserRepository>();
        _storageService = new Mock<IFileStorageService>();


        // JWT configuration for mocked IConfiguration.
        var configurationSettings = new Dictionary<string, string>
            {
                {"Jwt:Key", "erhgrRTGsadfef545erdgdfgr6tDFHGR4653fgdggsdf" },
                {"Jwt:Issuer", "testIssuer" },
                {"Jwt:Audience", "testAudience" }
        };

        _configuration.Setup(config => config[It.IsAny<string>()]).Returns((string key) => configurationSettings.TryGetValue(key, out string? value) ? value : null);
    }

    [Test]
    public async Task LoginAsyncWithValidUserShouldReturnJWT()
    {
        // Arrange

        var fixture = new Fixture();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var userLoginDto = fixture.Create<UserLoginDTO>();
        var userEntity = fixture.Create<ApplicationUser>();

        _signInManager.Setup(m => m.CheckPasswordSignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), false)).ReturnsAsync(SignInResult.Success);
        _userRepository.Setup(m => m.GetAsync(x => x.UserName == userLoginDto.LoginCode, default)).ReturnsAsync(userEntity);
        _userManager.Setup(m => m.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(["Receptionist"]);

        var userService = new UserService(_emailService.Object, _signInManager.Object, _userManager.Object, _mapper, _userRepository.Object, _configuration.Object, _storageService.Object);

        // Act

        var actual = await userService.LoginAsync(userLoginDto);

        // Assert

        Assert.That(actual, Is.Not.Null);
    }

    [Test]
    public void LoginAsyncWithInvalidUserOrPasswordThrows()
    {
        // Arrange

        var fixture = new Fixture();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var userLoginDto = fixture.Create<UserLoginDTO>();
        var userEntity = fixture.Create<ApplicationUser>();

        _signInManager.Setup(m => m.CheckPasswordSignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), false)).ReturnsAsync(SignInResult.Failed);
        _userRepository.Setup(m => m.GetAsync(x => x.UserName == userLoginDto.LoginCode, default)).ReturnsAsync(userEntity);
        _userManager.Setup(m => m.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(["Owner"]);

        var userService = new UserService(_emailService.Object, _signInManager.Object, _userManager.Object, _mapper, _userRepository.Object, _configuration.Object, _storageService.Object);

        // Act & Assert

        var ex = Assert.ThrowsAsync<CustomException>(async () => await userService.LoginAsync(userLoginDto));
        Assert.Multiple(() =>
        {
            Assert.That(ex.Message, Is.EqualTo("Invalid login code or password!"));
            Assert.That(ex.StatusCode, Is.EqualTo(400));
        });

    }

    [Test]
    public async Task RegisterAsyncShouldReturnTrue()
    {
        // Arrange
        var fixture = new Fixture();

        fixture.Customize(new AutoMoqCustomization());

        var userToAddDTO = fixture.Create<UserToAddDTO>();

        var successUploadResult = fixture.Build<FileUploadResult>()
            .With(p => p.StatusCode, HttpStatusCode.OK)
            .Create();

        _userManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), userToAddDTO.Password)).ReturnsAsync(IdentityResult.Success);
        _storageService.Setup(m => m.UploadAsync(userToAddDTO.ProfilePicture, It.IsAny<string>())).ReturnsAsync(successUploadResult);

        var userService = new UserService(_emailService.Object, _signInManager.Object, _userManager.Object, _mapper, _userRepository.Object, _configuration.Object, _storageService.Object);

        // Act

        var actual = await userService.RegisterAsync(userToAddDTO);

        // Assert

        Assert.That(actual, Is.True);
    }

    [Test]
    public async Task RegisterAsyncWithFaildImageUploadShouldReturnTrue()
    {
        // Arrange
        var fixture = new Fixture();

        fixture.Customize(new AutoMoqCustomization());

        var userToAddDTO = fixture.Create<UserToAddDTO>();

        var faildUploadResult = fixture.Build<FileUploadResult>()
            .With(p => p.StatusCode, HttpStatusCode.BadRequest)
            .Create();

        _userManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), userToAddDTO.Password)).ReturnsAsync(IdentityResult.Success);
        _storageService.Setup(m => m.UploadAsync(userToAddDTO.ProfilePicture, It.IsAny<string>())).ReturnsAsync(faildUploadResult);

        var userService = new UserService(_emailService.Object, _signInManager.Object, _userManager.Object, _mapper, _userRepository.Object, _configuration.Object, _storageService.Object);

        // Act

        var actual = await userService.RegisterAsync(userToAddDTO);

        // Assert

        Assert.That(actual, Is.True);
    }

    [Test]
    public async Task RegisterAsyncWithFaildUserCreateShouldReturnFalse()
    {
        // Arrange
        var fixture = new Fixture();

        fixture.Customize(new AutoMoqCustomization());

        var userToAddDTO = fixture.Create<UserToAddDTO>();

        var faildUploadResult = fixture.Build<FileUploadResult>()
            .With(p => p.StatusCode, HttpStatusCode.BadRequest)
            .Create();

        _userManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), userToAddDTO.Password)).ReturnsAsync(IdentityResult.Failed());
        _storageService.Setup(m => m.UploadAsync(userToAddDTO.ProfilePicture, It.IsAny<string>())).ReturnsAsync(faildUploadResult);

        var userService = new UserService(_emailService.Object, _signInManager.Object, _userManager.Object, _mapper, _userRepository.Object, _configuration.Object, _storageService.Object);

        // Act

        var actual = await userService.RegisterAsync(userToAddDTO);

        // Assert

        Assert.That(actual, Is.False);
    }
}
