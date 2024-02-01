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
}