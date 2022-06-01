using System.ComponentModel.DataAnnotations;
using ProjectManagement.Base;

namespace ProjectManagement.Features.Users;

public class User : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}