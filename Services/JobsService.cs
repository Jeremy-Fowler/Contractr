using Contractr.Models;
using Contractr.Repositories;

namespace Contractr.Services
{
  public class JobsService
  {
    private readonly JobsRepository _jr;
    private readonly CompaniesService _cs;

    public JobsService(JobsRepository jr, CompaniesService cs)
    {
      _jr = jr;
      _cs = cs;
    }

    internal Job Create(Job data)
    {
      return _jr.Create(data);
    }
  }
}