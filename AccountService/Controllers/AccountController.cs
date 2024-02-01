using Microsoft.AspNetCore.Mvc;
using AccountService.InterfaceRepository;
using AccountService.Entities;
using AccountService.Exception;
using Newtonsoft.Json;
using AccountService.DTOs;
using AccountService.InterfaceService;

namespace AccountService.Controllers;

[ApiController]
[Route("api/account")]
// [ServiceFilter(typeof(AccountFilter), Order=1)]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly IJwtService _jwtService;

    public AccountController(IAccountRepository accountRepo, IJwtService jwtService){
        _accountRepo = accountRepo;
        _jwtService = jwtService;
    }

    // GET: /api/account
    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_accountRepo.GetAccounts());
    }

    // GET: /api/account/{id}
    [HttpGet("{id}")]
    public IActionResult FindById(int id)
    {
        return Ok(_accountRepo.GetAccount(id));
    }

    // POST: /api/account
    [HttpPost]
    public IActionResult Register([FromBody] Account account)
    {
        try
        {
            // _accountRepo.CreateAccount(account);
            HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
            Random random = new Random();

            // Generate a 6-digit random number
            int number = random.Next(100000, 999999);

            // Convert the number to a string
            string code = number.ToString();
            HttpContext.Session.SetString("code_register", code);
            return Ok();
        }
        catch (InvalidParamsException e)
        {
            return StatusCode(e.Code, e.Message);
        }
    }

    [HttpGet("confirm")]
    public IActionResult ConfirmAccount([FromQuery] string code)
    {
        string _code = HttpContext.Session.GetString("code");
        if (_code.Equals(code))
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("auth")]
    public IActionResult Login([FromBody] LoginAccount account)
    {
        try
        {
            Account _account = _accountRepo.LoginAccount(account);
            var token = _jwtService.GenerateToken(_account.Username,1000);
            return Ok(token);
        }
        catch (InvalidParamsException e)
        {
            return StatusCode(e.Code, e.Message);
        }
    }

    [HttpGet("logout")]
    public IActionResult LogoutAccount()
    {
        HttpContext.Session.Remove("account");
        return Ok();
    }

    [HttpGet("error")]
    public IActionResult Error()
    {
        return StatusCode(400, "Invalid API");
    }
}