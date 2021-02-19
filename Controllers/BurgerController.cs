using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;
using cburgerapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cburgerapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {
    private readonly BurgerService _bs;
    public BurgerController(BurgerService bs)
    {
      _bs=bs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
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
    public ActionResult<Burger> GetBurgerById(int id)
    {
     try{
       return Ok(_bs.GetBurgerById(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try{
        return Ok(_bs.Create(newBurger));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Burger> Edit(int id, [FromBody] Burger editBurger)
    {
      try{
        editBurger.Id=id;
        return Ok(_bs.Edit(editBurger));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
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