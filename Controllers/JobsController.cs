using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gregslist_api.Models;
using gregslist_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gregslist_api.Controllers
{
  // NOTE use this if you want to lock the entire controller and all its routes
  // [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _service;

    public JobsController(JobsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // NOTE use this if you want to lock just this route
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Job>> GetMyJobs()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a job, yo.");
        }
        return Ok(_service.Get(user.Value));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a job, yo.");
        }
<<<<<<< HEAD
        newJob.User = user.Value;
=======
        newJob.UserId = user.Value;
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
        return Ok(_service.Create(newJob));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a job, yo.");
        }
        return Ok(_service.Delete(user.Value, id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Job> Update(int id, [FromBody] Job updatedJob)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a job, yo.");
        }
<<<<<<< HEAD
        updatedJob.User = user.Value;
=======
        updatedJob.UserId = user.Value;
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
        updatedJob.Id = id;
        return Ok(_service.Update(updatedJob));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}
