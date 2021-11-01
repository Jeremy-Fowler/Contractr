namespace Contractr.Models
{
  public class Account : DBItem<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}