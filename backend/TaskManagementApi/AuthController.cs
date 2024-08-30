using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtAuthenticationManager _jwtAuthenticationManager;

    public AuthController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        _jwtAuthenticationManager = jwtAuthenticationManager;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserCredentials userCredentials)
    {
        var token = _jwtAuthenticationManager.Authenticate(userCredentials.Username, userCredentials.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}

public class UserCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}