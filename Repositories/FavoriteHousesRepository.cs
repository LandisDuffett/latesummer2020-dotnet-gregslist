using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
  public class FavoriteHousesRepository
  {
    private readonly IDbConnection _db;

    public FavoriteHousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal DTOFavoriteHouse Create(DTOFavoriteHouse newFavoriteHouse)
    {
      string sql = @"INSERT INTO favoriteHouses
            (houseId, userId)
            VALUES
            (@HouseId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      newFavoriteHouse.Id = _db.ExecuteScalar<int>(sql, newFavoriteHouse);
      return newFavoriteHouse;
    }

    internal IEnumerable<ViewModelHouse> Get(string userId)
    {
      string sql = @"
            SELECT
            h.*,
            fh.id as FavoriteHouseId
            FROM favoriteHouses fh
            INNER JOIN houses h ON h.id = fh.houseId
            WHERE userId = @userId;
            ";
      return _db.Query<ViewModelHouse>(sql, new { userId });
    }
  }
}