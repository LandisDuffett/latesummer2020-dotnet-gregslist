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
    public string User { get; set; }
  }
  public class ViewModelJob : Job
  {
    // NOTE this is the relationship id
    public int FavoriteJobId { get; set; }
    // public ViewModelCar()
    // {

    // }

    // this is where you could pass the car to "Base" which is your parent class in the inheritance chain. "Car"
    // public ViewModelCar(Car car) : base(car)
    // {
    // CarId = car.Id
    // }

  }
}