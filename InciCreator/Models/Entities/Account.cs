using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InciCreator.Models.Entities;

[Table("account")]
[Index(nameof(Name), IsUnique = true)]
public class Account
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(63)]
    public string Name { get; set; }

    [Column("contact_id")]
    public int ContactId { get; set; }

    public Contact Contact { get; set; }

    public ICollection<Incident> Incidents { get; set; }
}
