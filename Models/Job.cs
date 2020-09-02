using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
  public class Job
  {
    public int Id { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public int Pay { get; set; }
    public string Title { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}