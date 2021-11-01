using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contractr.Interfaces;
using Contractr.Models;
using Dapper;

namespace Contractr.Repositories
{
  public class ContractorsRepository : IRepository<Contractor>
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Contractor Create(Contractor data)
    {
      string sql = @"
      INSERT INTO contractors(
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

    internal List<Job> GetContractorsByCompanyId(int id)
    {
      string sql = @"
      SELECT j.*, c.*
      FROM jobs j
      JOIN contractors c ON c.id = j.contractorId
      WHERE j.companyId = @id
      ";

      return _db.Query<Job, Contractor, Job>(sql, (j, c) =>
      {
        j.Contractor = c;
        return j;
      }, new { id }).ToList();
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1;";

      int affectedRows = _db.Execute(sql, new {id});
      if(affectedRows == 0)
      {
        throw new Exception("WHAT HAPPEN");
      }
    }

    public Contractor Edit(Contractor data)
    {
      throw new System.NotImplementedException();
    }

    public List<Contractor> Get()
    {
      throw new System.NotImplementedException();
    }

    public Contractor Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}