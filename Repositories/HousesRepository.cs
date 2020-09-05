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
<<<<<<< HEAD
      string sql = "SELECT * FROM houses WHERE user = @User;";
=======
      string sql = "SELECT * FROM houses WHERE userId = @UserId;";
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
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
<<<<<<< HEAD
            (floors, sizeSqFt, price, description, imgUrl, user)
            VALUES
            (@floors, @sizeSqFt, @price, @description, @imgUrl, @user);
=======
            (floors, sizeSqFt, price, description, imgUrl, userId)
            VALUES
            (@floors, @sizeSqFt, @price, @description, @imgUrl, @userId);
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
            SELECT LAST_INSERT_ID();";
      newHouse.Id = _db.ExecuteScalar<int>(sql, newHouse);
      return newHouse;
    }
<<<<<<< HEAD
    public bool Delete(string user, int id)
    {
      string sql = "DELETE FROM houses WHERE id = @Id AND user = @User LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { user, id });
=======
    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM houses WHERE id = @Id AND userId = @UserId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
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
<<<<<<< HEAD
            WHERE id = @id AND user = @user LIMIT 1;";
=======
            WHERE id = @id AND userId = @userId LIMIT 1;";
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      int rowsAffected = _db.Execute(sql, updatedHouse);
      return rowsAffected == 1;
    }
  }
}