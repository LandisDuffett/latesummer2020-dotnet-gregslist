using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
  public class House
  {
    public int Id { get; set; }
    [Required]
    public int Floors { get; set; }
    [Required]
    public int SizeSqFt { get; set; }
    [Required]
    public int Price { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}