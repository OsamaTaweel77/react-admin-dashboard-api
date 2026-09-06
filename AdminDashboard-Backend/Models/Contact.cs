using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboardAPI.Models;

public class Contact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }

    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Address { get; set; }

    [Required]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? ZipCode { get; set; }

    public int? RegistrarId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}