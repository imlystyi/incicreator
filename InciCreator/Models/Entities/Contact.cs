using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InciCreator.Models.Entities;

[Table("contact")]
[Index(nameof(Email), IsUnique = true)]
public class Contact
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("first_name")]
    [MaxLength(63)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [MaxLength(63)]
    public string LastName { get; set; }

    [Column("email")]
    [MaxLength(127)]
    public string Email { get; set; }

    public ICollection<Account> Accounts { get; set; }
}
