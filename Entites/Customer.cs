using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Entites;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; set; }

    [StringLength(50)]
    public string Email { get; set; }
}
