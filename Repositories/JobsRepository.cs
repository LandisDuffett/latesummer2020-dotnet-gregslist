using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Job> Get()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }
    public IEnumerable<Job> Get(string userId)
    {
<<<<<<< HEAD
      string sql = "SELECT * FROM jobs WHERE user = @User;";
=======
      string sql = "SELECT * FROM jobs WHERE userId = @UserId;";
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      return _db.Query<Job>(sql, new { userId });
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    public Job Create(Job newJob)
    {
      string sql = @"INSERT INTO jobs
<<<<<<< HEAD
            (company, pay, title, user)
            VALUES
            (@company, @pay, @title, @user);
=======
            (company, pay, title, userId)
            VALUES
            (@company, @pay, @title, @userId);
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
            SELECT LAST_INSERT_ID();";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }
<<<<<<< HEAD
    public bool Delete(string user, int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @Id AND user = @User LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { user, id });
=======
    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @Id AND userId = @UserId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      return rowsAffected == 1;
    }

    public bool Update(Job updatedJob)
    {
      string sql = @"UPDATE jobs
            SET 
            company = @company,
            pay = @pay,
            title = @title
<<<<<<< HEAD
            WHERE id = @id AND user = @user LIMIT 1;";
=======
            WHERE id = @id AND userId = @userId LIMIT 1;";
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
      int rowsAffected = _db.Execute(sql, updatedJob);
      return rowsAffected == 1;
    }
  }
}