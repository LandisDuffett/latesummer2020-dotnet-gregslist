using System;
using System.Collections;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;

namespace gregslist_api.Services
{
  public class FavoriteHousesService
  {
    private readonly FavoriteHousesRepository _repo;
    private readonly HousesService _houseService;

    public FavoriteHousesService(FavoriteHousesRepository repo, HousesService houseService)
    {
      _repo = repo;
      _houseService = houseService;
    }

    internal DTOFavoriteHouse Create(DTOFavoriteHouse newFavoriteHouse)
    {
      // Car car = _carService.GetById(newFavoriteCar.CarId);
      // newFavoriteCar = _repo.Create(newFavoriteCar);
      // ViewModelCar favoriteCar = new ViewModelCar();
      return _repo.Create(newFavoriteHouse);
    }

    internal IEnumerable<ViewModelHouse> Get(string userId)
    {
      return _repo.Get(userId);
    }
  }
}