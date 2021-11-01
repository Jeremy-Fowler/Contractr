using System.Data;
using Contractr.Models;
using Dapper;

namespace Contractr.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Job Create(Job data)
    {
      string sql = @"
      INSERT INTO jobs(
        companyId,
        contractorId
      )
      Values(
        @CompanyId,
        @ContractorId
      );
      SELECT LAST_INSERT_ID();
      ";

      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }
  }
}