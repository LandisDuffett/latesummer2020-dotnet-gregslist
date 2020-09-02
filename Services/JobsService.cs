using System;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_api.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Job> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Job> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Job GetById(int id)
    {
      Job foundJob = _repo.GetById(id);
      if (foundJob == null)
      {
        throw new Exception("Invalid job Id");
      }
      return foundJob;
    }
    public Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    public string Delete(string userId, int id)
    {
      GetById(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this job");
      }
      return "Delorted!";
    }

    public Job Update(Job updatedJob)
    {
      Job foundJob = GetById(updatedJob.Id);
      updatedJob.Company = updatedJob.Company == null ? foundJob.Company : updatedJob.Company;
      updatedJob.Title = updatedJob.Title == null ? foundJob.Title : updatedJob.Title;
      updatedJob.Pay = updatedJob.Pay == 0 ? foundJob.Pay : updatedJob.Pay;
      updatedJob.UserId = updatedJob.UserId == null ? foundJob.UserId : updatedJob.UserId;
      bool updated = _repo.Update(updatedJob);
      if (!updated)
      {
        throw new Exception("Oops ALL BERRIES You are not the owner of this job");
      }
      return updatedJob;
    }
  }
}