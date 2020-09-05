using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<House> Get()
    {
      string sql = "SELECT * FROM houses";
      return _db.Query<House>(sql);
    }
    public IEnumerable<House> Get(string userId)
    {
      string sql = "SELECT * FROM houses WHERE user = @User;";
      return _db.Query<House>(sql, new { userId });
    }

    internal House GetById(int id)
    {
      string sql = "SELECT * FROM houses WHERE id = @Id;";
      return _db.QueryFirstOrDefault<House>(sql, new { id });
    }

    public House Create(House newHouse)
    {
      string sql = @"INSERT INTO houses
            (floors, sizeSqFt, price, description, imgUrl, user)
            VALUES
            (@floors, @sizeSqFt, @price, @description, @imgUrl, @user);
            SELECT LAST_INSERT_ID();";
      newHouse.Id = _db.ExecuteScalar<int>(sql, newHouse);
      return newHouse;
    }
    public bool Delete(string user, int id)
    {
      string sql = "DELETE FROM houses WHERE id = @Id AND user = @User LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { user, id });
      return rowsAffected == 1;
    }

    public bool Update(House updatedHouse)
    {
      string sql = @"UPDATE houses
            SET 
            floors = @floors,
            sizeSqFt = @sizeSqFt,
            price = @price,
            description = @description,
            imgUrl = @imgUrl
            WHERE id = @id AND user = @user LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedHouse);
      return rowsAffected == 1;
    }
  }
}