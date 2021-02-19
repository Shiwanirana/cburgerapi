using System.Collections.Generic;
using System.Data;
using cburgerapi.Models;
using Dapper;

namespace cburgerapi
{
  public class DrinkRepository
  {
    public readonly IDbConnection _db;
    public DrinkRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Drink> GetAll()
    {
      string sql = "SELECT * FROM drinks;";
      return _db.Query<Drink>(sql);
    }
    internal Drink GetById(int id)
    {
      string sql = "SELECT * FROM drinks WHERE id = @id;";
      return _db.QueryFirstOrDefault<Drink>(sql, new {id});
    }
    internal Drink Create(Drink newDrink)
    {
     string sql = @"
     INSERT INTO drinks
     (name,price,description)
     VALUES
     (@Name,@Price,@Description);
     SELECT LAST_INSERT_ID();";
     int id = _db.ExecuteScalar<int>(sql, newDrink);
     newDrink.Id = id;
     return newDrink;
    }
    internal Drink Edit(Drink original)
    {
      string sql = @"
      UPDATE drinks
      SET
       name = @Name,
       price=@Price,
       description = @Description
       WHERE id=@Id;
       SELECT * FROM drinks WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Drink>(sql,original);
    }
    internal void Delete(Drink drink)
    {
      string sql = "DELETE FROM drinks WHERE id= @Id";
      _db.Execute(sql,drink);
    }
  }
}