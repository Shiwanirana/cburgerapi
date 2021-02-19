using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;
using cburgerapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cburgerapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DrinksController : ControllerBase
  {
    private readonly DrinksService _bs;
    public DrinksController(DrinksService bs)
    {
      _bs=bs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      try{
      return Ok(_bs.Get());
      }
      catch(System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Drink> GetDrinkById(int id)
    {
     try{
       return Ok(_bs.GetDrinkById(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
      try{
        return Ok(_bs.Create(newDrink));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Drink> Edit(int id, [FromBody] Drink editDrink)
    {
      try{
        editDrink.Id=id;
        return Ok(_bs.Edit(editDrink));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Drink> Delete(int id)
    {
     try{
      return Ok(_bs.Delete( id ));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
  }
}