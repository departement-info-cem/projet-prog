using System.ComponentModel.DataAnnotations;

namespace Models.Models.Dtos.Account;

public class LoginDTO
{
    [Required]
    public string Username { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
}

public class LoginSuccessDTO
{
    [Required]
    public string Token { get; set; } = "";
}