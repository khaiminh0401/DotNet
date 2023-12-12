using System.ComponentModel.DataAnnotations;

namespace AccountService.Entities;

public class Account
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Username {get; set;}
    public string? Password {get; set;}
    // public DateTime CreateDate{get;set;}

    public Account()
    {
    }
    public Account(int id,string username ,string password)
    {
        this.Id = id;
        this.Username = username;
        this.Password = password;
        // this.CreateDate = createDate;
    }
        public Account(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
}