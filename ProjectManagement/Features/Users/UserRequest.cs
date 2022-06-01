using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Features.Users;

public class UserRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}