using System.Collections.Generic;
using System.Data;
using cburgerapi.Models;
using Dapper;

namespace cburgerapi
{
  public class BurgerRepository
  {
    public readonly IDbConnection _db;
    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burger;";
      return _db.Query<Burger>(sql);
    }
    internal Burger GetById(int id)
    {
      string sql = "SELECT * FROM burger WHERE id = @id;";
      return _db.QueryFirstOrDefault<Burger>(sql, new {id});
    }
    internal Burger Create(Burger newBurger)
    {
     string sql = @"
     INSERT INTO burger
     (name,bun,price,toppings,description)
     VALUES
     (@Name,@Bun,@Price,@Toppings,@Description);
     SELECT LAST_INSERT_ID();";
     int id = _db.ExecuteScalar<int>(sql, newBurger);
     newBurger.Id = id;
     return newBurger;
    }
    internal Burger Edit(Burger original)
    {
      string sql = @"
      UPDATE burger
      SET
       name = @Name,
       bun = @Bun,
       price=@Price,
       description = @Description,
       toppings=@Toppings
       WHERE id=@Id;
       SELECT * FROM burger WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Burger>(sql,original);
    }
    internal void Delete(Burger burger)
    {
      string sql = "DELETE FROM burger WHERE id= @Id";
      _db.Execute(sql,burger);
    }
  }
}