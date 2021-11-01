using System;
using System.ComponentModel.DataAnnotations;

namespace Contractr.Models
{
  public abstract class DBItem<T>
  {
    [Required]
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}