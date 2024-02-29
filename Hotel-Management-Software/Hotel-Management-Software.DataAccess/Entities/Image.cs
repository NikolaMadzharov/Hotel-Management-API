namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string PublicId { get; set; } = null!;

    [Required]
    public string URL { get; set; } = null!;
}
