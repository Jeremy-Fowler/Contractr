using System.Collections.Generic;

namespace Contractr.Interfaces
{
  public interface IRepository<T>
  {
    List<T> Get();
    T Get(int id);
    T Create(T data);
    T Edit(T data);
    void Delete(int id);
  }
}