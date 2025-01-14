using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models.Dtos.Account;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace LapinCouvertAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Register(RegisterDTO registerDto)
    {
        if (registerDto.Password != registerDto.PasswordConfirm)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
        }

        IdentityUser user = new()
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };
        IdentityResult identityResult = await userManager.CreateAsync(user, registerDto.Password);

        if (!identityResult.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
        }

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginDTO loginDto)
    {
        SignInResult result =
            await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, true,
                lockoutOnFailure: false);

        if (!result.Succeeded)
            return BadRequest(new { Code = "WrongPassword" });

        Claim? nameIdentifierClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

        List<Claim> authClaims =
        [
            nameIdentifierClaim ?? throw new InvalidOperationException(),
            new("username", User.Identity?.Name ?? throw new InvalidOperationException()),
        ];

        SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            "C'est tellement la meilleure cle qui a jamais ete cree dans l'histoire de l'humanite (doit etre longue)"));

        string issuer = Request.Scheme + "://" + Request.Host;

        DateTime expirationTime = DateTime.Now.AddMinutes(30);

        JwtSecurityToken token = new(
            issuer: issuer,
            audience: null,
            claims: authClaims,
            expires: expirationTime,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new LoginSuccessDTO() { Token = tokenString });
    }
}