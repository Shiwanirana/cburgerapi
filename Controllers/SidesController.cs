using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;
using cburgerapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cburgerapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SidesController : ControllerBase
  {
    private readonly SidesService _bs;
    public SidesController(SidesService bs)
    {
      _bs=bs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
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
    public ActionResult<Side> GetSideById(int id)
    {
     try{
       return Ok(_bs.GetSideById(id));
     }
     catch(System.Exception err){
       return BadRequest(err.Message);
     }
    }
    [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
      try{
        return Ok(_bs.Create(newSide));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Side> Edit(int id, [FromBody] Side editSide)
    {
      try{
        editSide.Id=id;
        return Ok(_bs.Edit(editSide));
      }
      catch(System.Exception err){
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Side> Delete(int id)
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