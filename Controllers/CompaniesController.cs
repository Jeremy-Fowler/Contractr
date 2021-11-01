using System.Collections.Generic;
using Contractr.Models;
using Contractr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contractr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    
    private readonly CompaniesService _companiesService;
    private readonly ContractorsService _contractorsService;

    public CompaniesController(CompaniesService companiesService, ContractorsService contractorsService)
    {
      _companiesService = companiesService;
      _contractorsService = contractorsService;
    }



    [HttpPost]
    public ActionResult<Company> Create([FromBody] Company data)
    {
      try
      {
          Company company = _companiesService.Create(data);
          return Ok(company);    
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/contractors")]
    public ActionResult<List<Job>> GetContractorsByCompanyId(int id)
    {
      try
      {
          List<Job> contractors = _contractorsService.GetGetContractorsByCompanyId(id);
          return Ok(contractors);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}