using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;


public class UserRequestModel
{
    [Required(ErrorMessage = "Ange ett giltligt förnamn")]
    [MinLength(2)]

    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]

    public string LastName { get; set; } = null!;


    [EmailAddress]

    public string Email { get; set; } = null!;
}