
using System.Collections.Generic;
using System.Data;
using Dapper;
using pizzadon.Models;

namespace pizzadon.Repositories
{
  public class PizzaRepository
  {
    private IDbConnection _db;
    public PizzaRepository(IDbConnection db)
    {
      _db = db;
    }

    //get all pizzas
    public IEnumerable<Pizza> GetAll()
    {
      return _db.Query<Pizza>("SELECT * FROM Pizza");
    }

    //get pizza by id


    //post a new pizza
    public Pizza Create(Pizza pizza)
    {
      int pizzaID = _db.ExecuteScalar<int>(@"
      INSERT INTO Pizza (name, description)
      VALUES (@Name, @Description);
      SELECT LAST_INSERT_ID();", pizza
      );
      pizza.id = pizzaID;
      return pizza;
    }

    //put a pizza change

    //delete a pizza




  }

}

