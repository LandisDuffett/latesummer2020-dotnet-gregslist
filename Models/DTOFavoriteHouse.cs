using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
  public class DTOFavoriteHouse
  {
    public int Id { get; set; }
    [Required]
    public int HouseId { get; set; }
    public string UserId { get; set; }
  }
}