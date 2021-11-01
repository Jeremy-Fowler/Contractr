using System.Collections.Generic;
using Contractr.Models;
using Contractr.Repositories;

namespace Contractr.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _cr;

    public CompaniesService(CompaniesRepository cr)
    {
      _cr = cr;
    }

    internal Company Create(Company data)
    {
      return _cr.Create(data);
    }

    internal List<Job> GetGetContractorsByCompanyId(int id)
    {
      return _cr.GetGetContractorsByCompanyId(id);
    }
  }
}