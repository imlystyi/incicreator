using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InciCreator.Models.Entities;

[Table("incident")]
public class Incident
{
    [Column("name")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Name { get; set; }

    [Column("description")]
    [MaxLength(255)]
    public string Description { get; set; }

    [Column("account_id")]
    public int AccountId { get; set; }

    public Account Account { get; set; }
}
