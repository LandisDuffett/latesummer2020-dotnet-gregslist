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
<<<<<<< HEAD
    public string User { get; set; }
  }

  public class ViewModelHouse : House
  {
    // NOTE this is the relationship id
    public int FavoriteHouseId { get; set; }
    // public ViewModelCar()
    // {

    // }

    // this is where you could pass the car to "Base" which is your parent class in the inheritance chain. "Car"
    // public ViewModelCar(Car car) : base(car)
    // {
    // CarId = car.Id
    // }

=======
    [Required]
    public string UserId { get; set; }
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
  }
}