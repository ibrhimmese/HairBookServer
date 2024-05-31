using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangeEmail;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePassword;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePasswordAdmin;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.CreateRefreshToken;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Register;
using Application.Services.Repositories.RolBasedAccessControlRepositories.JwtProviderInterfaces;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.RolBasedAccessControlRepositories.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IJwtProvider jwtProvider, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
        _contextAccessor = contextAccessor;
    }

    public async Task<LoginCommandResponse> CreateRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null)
        {
            throw new Exception("Kullanıcı Bulunamadı");
        }
        if (user.RefreshToken != request.RefreshToken)
        {
            throw new Exception("Refresh Token Geçerli Değil");
        }
        if (user.RefreshTokenExpires < DateTime.Now)
        {
            throw new Exception("Refresh Token süresi geçerli değil");
        }
        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }

    //public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    //{
    //    User? user = await _userManager.Users
    //        .Where(
    //        p =>
    //    p.UserName == request.UserNameOrEmail
    //    || p.Email == request.UserNameOrEmail)
    //    .FirstOrDefaultAsync(cancellationToken);

    //    if (user is null) throw new Exception("Kullanıcı Bulunamadı!");

    //    var result = await _userManager.CheckPasswordAsync(user, request.Password);
    //    if (result)
    //    {
    //        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
    //        return response;
    //    }
    //    throw new Exception("Şifreyi yanlış girdiniz!");
    //}

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.Users
            .Where(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new Exception("Kullanıcı Bulunamadı!");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }
        throw new Exception("Şifreyi yanlış girdiniz!");
    }


    public async Task RegisterAsync(RegisterCommand request,CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request);
        user.Id=Guid.NewGuid().ToString();

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

    }
    public async Task ChangePasswordAsync(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        //User? user = await _userManager.FindByIdAsync(request.UserId);
        //if (user is null)
        //{
        //    throw new Exception("Kullanıcı Bulunamadı!");
        //}

        //var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        //if (!result.Succeeded)
        //{
        //    throw new Exception(result.Errors.First().Description);

        //}
        var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext!.User);
        if (user == null)
        {
            throw new Exception("Kullanıcı Bulunamadı!");
        }

        // Kullanıcı ID'sinin eşleşip eşleşmediğini kontrol et
        if (user.Id != request.UserId)
        {
            throw new Exception("Yalnızca kendi şifrenizi değiştirebilirsiniz!");
        }

        // Şifre değiştirme işlemi
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        // Şifre değiştirildikten sonra kullanıcıyı yeniden oturum açtırmak
        await _signInManager.RefreshSignInAsync(user);
    }

    public async Task ChangePasswordAdminAsync(ChangePasswordAdminCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByNameAsync(request.UserId);
        if (user == null)
        {
            throw new Exception("Kullanıcı bulunamadı.");
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

         await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
         
    }

    public async Task ChangeEmailAsync(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null)
        {
            throw new Exception("Kullanıcı Bulunamadı");
        }
        user.Email = request.NewEmail;

        await _userManager.UpdateAsync(user);
    }
}
