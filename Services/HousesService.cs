using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Services
{
  public class HousesService
  {
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<House> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<House> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public House GetById(int id)
    {
      House foundHouse = _repo.GetById(id);
      if (foundHouse == null)
      {
        throw new Exception("Invalid house Id");
      }
      return foundHouse;
    }
    public House Create(House newHouse)
    {
      return _repo.Create(newHouse);
    }

    public string Delete(string userId, int id)
    {
      GetById(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this house");
      }
      return "Delorted!";
    }

    public House Update(House updatedHouse)
    {
      House foundHouse = GetById(updatedHouse.Id);
      updatedHouse.Floors = updatedHouse.Floors == 0 ? foundHouse.Floors : updatedHouse.Floors;
      updatedHouse.SizeSqFt = updatedHouse.SizeSqFt == 0 ? foundHouse.SizeSqFt : updatedHouse.SizeSqFt;
      updatedHouse.Price = updatedHouse.Price == 0 ? foundHouse.Price : updatedHouse.Price;
      updatedHouse.Description = updatedHouse.Description == null ? foundHouse.Description : updatedHouse.Description;
<<<<<<< HEAD
      updatedHouse.User = updatedHouse.User == null ? foundHouse.User : updatedHouse.User;
=======
      updatedHouse.UserId = updatedHouse.UserId == null ? foundHouse.UserId : updatedHouse.UserId;
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      updatedHouse.ImgUrl = updatedHouse.ImgUrl == null ? foundHouse.ImgUrl : updatedHouse.ImgUrl;
      bool updated = _repo.Update(updatedHouse);
      if (!updated)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this house");
      }
      return updatedHouse;
    }
  }
}