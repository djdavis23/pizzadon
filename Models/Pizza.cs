using System.ComponentModel.DataAnnotations;

namespace pizzadon.Models
{
  public class Pizza
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    [Required]
    public int id { get; set; }
    public Pizza()
    {

    }
    public Pizza(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}