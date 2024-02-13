namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

public class UserService : IUserService
{
    private readonly IEmailService _emailService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IEmailService emailService, 
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager, 
        IMapper mapper, 
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _emailService = emailService;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(UserLoginDTO userToLoginDTO)
    {
        var user = await _userRepository.GetAsync(x => x.UserName == userToLoginDTO.LoginCode);

        var result = await _signInManager.CheckPasswordSignInAsync(user, userToLoginDTO.Password, false);

        var token = JwtHelper.GenerateToken(user, _configuration);

        return token;
    }

    public async Task<bool> RegisterAsync(UserToAddDTO userToAddDTO)
    {
       

        var user = _mapper.Map<ApplicationUser>(userToAddDTO);

        var result =  await _userManager.CreateAsync(user, userToAddDTO.Password); 

        if (result.Succeeded)
        {
            await _emailService.SendLoginCodeAsync(user);
            return true;
        }


        return false;

         
        

    }
}
