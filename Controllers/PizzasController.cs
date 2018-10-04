using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzadon.Models;
using pizzadon.Repositories;

namespace pizzadon.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PizzasController : Controller
  {
    private PizzaRepository _repo;

    public PizzasController(PizzaRepository repo)
    {
      _repo = repo;
    }


    // GET api/Customers
    [HttpGet]
    public IEnumerable<Pizza> Get()
    {
      return _repo.GetAll();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public Pizza Post([FromBody] Pizza pizza)
    {
      return _repo.Create(pizza);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
