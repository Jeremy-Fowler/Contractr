using System.Collections.Generic;
using Contractr.Models;
using Contractr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contractr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    
    private readonly CompaniesService _companiesService;
    private readonly ContractorsService _contractorsService;

    public ContractorsController(CompaniesService companiesService, ContractorsService contractorsService)
    {
      _companiesService = companiesService;
      _contractorsService = contractorsService;
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor data)
    {
      try
      {
          Contractor contractor = _contractorsService.Create(data);
          return Ok(contractor);    
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/companies")]
    public ActionResult<List<Job>> GetCompaniesByContractorId(int id)
    {
      try
      {
          List<Job> companies = _companiesService.GetGetContractorsByCompanyId(id);
          return Ok(companies);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
          _contractorsService.Delete(id);
          return Ok("CONTRACTOR WAS DELETED");
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}