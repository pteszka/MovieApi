using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieApi.Models;

// [PrimaryKey("UserId")]
public class User
{
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }

    [EmailAddress]
    public required string Email { get; set; }
}