using System.ComponentModel.DataAnnotations;

namespace ShivaReborn.Utils;

public class LoginRequest
{
    [Required]
    [DataType(DataType.Password)]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}