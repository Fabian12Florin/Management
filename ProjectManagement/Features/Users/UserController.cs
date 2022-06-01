using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataBase;

namespace ProjectManagement.Features.Users;

[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly AppDbContext _appdbcontext;

    public UserController(AppDbContext appdbcontext)
    {
        _appdbcontext = appdbcontext;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Add([FromBody] UserRequest userRequest)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = userRequest.Email,
            Name = userRequest.Name,
            Password = userRequest.Password,
        };
        
        await _appdbcontext.Users.AddAsync(user);
        await _appdbcontext.SaveChangesAsync();
        
        return Ok(new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
        });
    }
    
    [HttpGet]
    public async Task<ActionResult<UserResponse>> Get()
    {
        return Ok(await _appdbcontext.Users.Select(
            user => new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            }
        ).ToListAsync());
    }
    
}