namespace AccountService.Models;

public class AccountModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public AccountModel()
    {
    }
    public AccountModel(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }

}