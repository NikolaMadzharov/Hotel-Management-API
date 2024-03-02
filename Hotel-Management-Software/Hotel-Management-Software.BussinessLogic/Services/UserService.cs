﻿namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

public class UserService : IUserService
{
    private readonly IEmailService _emailService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IFileStorageService _storageService;

    public UserService(IEmailService emailService, 
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager, 
        IMapper mapper, 
        IUserRepository userRepository,
        IConfiguration configuration,
        IFileStorageService storageService)
    {
        _emailService = emailService;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
        _configuration = configuration;
        _storageService = storageService;
    }

    public async Task<string> LoginAsync(UserLoginDTO userToLoginDTO)
    {
        var user = await _userRepository.GetAsync(x => x.UserName == userToLoginDTO.LoginCode);


        var result = await _signInManager.CheckPasswordSignInAsync(user, userToLoginDTO.Password, false);


        if (result.Succeeded is false)
        {
            throw new CustomException("Invalid login code or password!", 400);

        }


        var token = JwtHelper.GenerateToken(user, _configuration);

        return token;
    }

    public async Task<bool> RegisterAsync(UserToAddDTO userToAddDTO)
    {
        var user = _mapper.Map<ApplicationUser>(userToAddDTO);

        var result =  await _userManager.CreateAsync(user, userToAddDTO.Password); 

        if (result.Succeeded)
        {
            var imageUploadResult = await _storageService.UploadAsync(userToAddDTO.ProfilePicture, $"ProfilePictures/{Guid.NewGuid()}");

            if (imageUploadResult.StatusCode == HttpStatusCode.OK)
            {
                var image = _mapper.Map<Image>(imageUploadResult);
                user.Image = image!;
                _ = await _userRepository.UpdateAsync(user);
            }

            await _emailService.SendLoginCodeAsync(user);
            return true;
        }


        return false;
    }
}
