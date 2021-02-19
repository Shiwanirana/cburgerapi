using System.Collections.Generic;
using cburgerapi.Models;

namespace cburgerapi.db
{
  public class FAKEDB
  {
    public static List<Burger> Burgers {get;set;} = new List<Burger>();
  }
}