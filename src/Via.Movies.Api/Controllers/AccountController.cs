using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Via.Movies.Api.Models;
using Via.Movies.Api.Dtos;

namespace Via.Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<ActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);

        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    

    [HttpPost]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Create the user
        var user = new User
        {
            Email = registerRequest.Email,
            UserName = registerRequest.Email
        };

        var result = await this.userManager.CreateAsync(user, registerRequest.Password);
        if (result.Succeeded)
        {
            return RedirectToPage("/Account/Login");
        }
        else
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("Register", error.Description);
            }

            return BadRequest(ModelState);
        }
    }
}