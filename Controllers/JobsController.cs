using Contractr.Models;
using Contractr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contractr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    public ActionResult<Job> Create([FromBody] Job data)
    {
      try
      {
          Job job = _js.Create(data);
          return Ok(job);     
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}