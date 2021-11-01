using System.Collections.Generic;
using Contractr.Models;
using Contractr.Repositories;

namespace Contractr.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _cr;

    public ContractorsService(ContractorsRepository cr)
    {
      _cr = cr;
    }

    internal Contractor Create(Contractor data)
    {
      return _cr.Create(data);
    }

    internal List<Job> GetGetContractorsByCompanyId(int id)
    {
      return _cr.GetContractorsByCompanyId(id);
    }

    internal void Delete(int id)
    {
      _cr.Delete(id);
    }
  }
}