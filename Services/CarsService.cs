using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Car> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Car> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Car GetById(int id)
    {
      Car foundCar = _repo.GetById(id);
      if (foundCar == null)
      {
        throw new Exception("Invalid car Id");
      }
      return foundCar;
    }
    public Car Create(Car newCar)
    {
      return _repo.Create(newCar);
    }

    public string Delete(string userId, int id)
    {
      GetById(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this car");
      }
      return "Delorted!";
    }

    public Car Update(Car updatedCar)
    {
      Car foundCar = GetById(updatedCar.Id);
      updatedCar.Make = updatedCar.Make == null ? foundCar.Make : updatedCar.Make;
      updatedCar.Model = updatedCar.Model == null ? foundCar.Model : updatedCar.Model;
      updatedCar.Year = updatedCar.Year == 0 ? foundCar.Year : updatedCar.Year;
      updatedCar.Price = updatedCar.Price == 0 ? foundCar.Price : updatedCar.Price;
      updatedCar.Description = updatedCar.Description == null ? foundCar.Description : updatedCar.Description;
<<<<<<< HEAD
      updatedCar.User = updatedCar.User == null ? foundCar.User : updatedCar.User;
=======
      updatedCar.UserId = updatedCar.UserId == null ? foundCar.UserId : updatedCar.UserId;
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      updatedCar.ImgUrl = updatedCar.ImgUrl == null ? foundCar.ImgUrl : updatedCar.ImgUrl;
      bool updated = _repo.Update(updatedCar);
      if (!updated)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this car");
      }
      return updatedCar;
    }
  }
}