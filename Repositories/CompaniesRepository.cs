using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contractr.Interfaces;
using Contractr.Models;
using Dapper;

namespace Contractr.Repositories
{
  public class CompaniesRepository : IRepository<Company>
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Company Create(Company data)
    {
      string sql = @"
      INSERT INTO companies(
        name
      )
      VALUES(
        @Name
      );
      SELECT LAST_INSERT_ID();
      ";

      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

    internal List<Job> GetGetContractorsByCompanyId(int id)
    {
      string sql = @"
      SELECT j.*, c.*
      FROM jobs j
      JOIN companies c ON c.id = j.companyId
      WHERE j.contractorId = @id
      ";

      return _db.Query<Job, Company, Job>(sql, (j, c) =>
      {
        j.Company = c;
        return j;
      }, new { id }).ToList();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Company Edit(Company data)
    {
      throw new System.NotImplementedException();
    }

    public List<Company> Get()
    {
      throw new System.NotImplementedException();
    }

    public Company Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}