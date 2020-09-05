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

  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class FavoriteHousesController : ControllerBase
  {
    private readonly FavoriteHousesService _service;

    public FavoriteHousesController(FavoriteHousesService service)
    {
      _service = service;
    }


    [HttpPost]
    public ActionResult<DTOFavoriteHouse> Create([FromBody] DTOFavoriteHouse newFavoriteHouse)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to favorite a house, yo.");
        }
        newFavoriteHouse.UserId = user.Value;
        return Ok(_service.Create(newFavoriteHouse));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<ViewModelHouse>> Get()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to get yo favorite houses, yo.");
        }
        return Ok(_service.Get(user.Value));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}
