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
      string sql = "SELECT * FROM jobs WHERE user = @User;";
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
            (company, pay, title, user)
            VALUES
            (@company, @pay, @title, @user);
            SELECT LAST_INSERT_ID();";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }
    public bool Delete(string user, int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @Id AND user = @User LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { user, id });
      return rowsAffected == 1;
    }

    public bool Update(Job updatedJob)
    {
      string sql = @"UPDATE jobs
            SET 
            company = @company,
            pay = @pay,
            title = @title
            WHERE id = @id AND user = @user LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedJob);
      return rowsAffected == 1;
    }
  }
}