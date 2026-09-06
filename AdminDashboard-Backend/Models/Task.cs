using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboardAPI.Models;

public class Task
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public int Status { get; set; } = 0; // 0=جديد, 1=قيد التنفيذ, 2=مكتمل

    public DateTime? DueDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}