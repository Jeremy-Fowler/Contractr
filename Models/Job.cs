namespace Contractr.Models
{
  public class Job : DBItem<int>
  {
    public int CompanyId { get; set; }
    public int ContractorId { get; set; }

    public Company Company { get; set; }
    public Contractor Contractor { get; set; }
  }
}