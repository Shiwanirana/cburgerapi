using System;
using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;

namespace cburgerapi.Services
{
  public class SidesService
  {
    private readonly SideRepository _repo;
    public SidesService(SideRepository repo)
    {
      _repo=repo;
    }
   // GetAll
   public IEnumerable<Side> Get()
   {
     return _repo.GetAll();
   }
   //Get by Id
   public Side GetSideById(int id)
   {
    //  Burger burgerToReturn = FAKEDB.Burgers.Find(c=> c.Id==id);
    Side sideToReturn = _repo.GetById(id);
     if(sideToReturn==null)
     {
       throw new Exception("Invalid Id");
     }
     return sideToReturn;
   }
   //Create
   public Side Create(Side newSide)
   {
    //  FAKEDB.Sides.Add(newSide);
     return _repo.Create(newSide);
   }
   //Edit
   public Side Edit(Side editSide)
   {
    //  Side foundSide = FAKEDB.Sides.Find(c=> c.Id==editSide.Id);
    //  if(foundSide==null)
    //  {
    //    throw new Exception("Invalid Id");
    //  }
    //  FAKEDB.Sides.Remove(foundSide);
    //  FAKEDB.Sides.Add(editSide);
    //  return editSide;
    Side original = GetSideById(editSide.Id);
    original.Name = editSide.Name != null ? editSide.Name : original.Name;
      original.Description = editSide.Description != null ? editSide.Description : original.Description;
      original.Price = editSide.Price > 0 ? editSide.Price : original.Price;
      return _repo.Edit(original);
   }
   //Remove
   public Side Delete(int id)
   {
    //  Side sideToRemove = FAKEDB.Sides.Find(c=>c.Id==id);
    Side sideToRemove = GetSideById(id);
     if(sideToRemove==null)
     {
       throw new Exception("Invlid Id");
     }
     _repo.Delete(sideToRemove);
    //  FAKEDB.Burgers.Remove(burgerToRemove);
     return sideToRemove;
   }
  }
}