using System;
using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;

namespace cburgerapi.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _repo;
    public BurgerService(BurgerRepository repo)
    {
      _repo=repo;
    }
   // GetAll
   public IEnumerable<Burger> Get()
   {
     return _repo.GetAll();
   }
   //Get by Id
   public Burger GetBurgerById(int id)
   {
    //  Burger burgerToReturn = FAKEDB.Burgers.Find(c=> c.Id==id);
    Burger burgerToReturn = _repo.GetById(id);
     if(burgerToReturn==null)
     {
       throw new Exception("Invalid Id");
     }
     return burgerToReturn;
   }
   //Create
   public Burger Create(Burger newBurger)
   {
    //  FAKEDB.Burgers.Add(newBurger);
     return _repo.Create(newBurger);
   }
   //Edit
   public Burger Edit(Burger editBurger)
   {
    //  Burger foundBurger = FAKEDB.Burgers.Find(c=> c.Id==editBurger.Id);
    //  if(foundBurger==null)
    //  {
    //    throw new Exception("Invalid Id");
    //  }
    //  FAKEDB.Burgers.Remove(foundBurger);
    //  FAKEDB.Burgers.Add(editBurger);
    //  return editBurger;
    Burger original = GetBurgerById(editBurger.Id);
    original.Name = editBurger.Name != null ? editBurger.Name : original.Name;
     original.Bun = editBurger.Bun != null ? editBurger.Bun : original.Bun;
      original.Toppings = editBurger.Toppings != null ? editBurger.Toppings : original.Toppings;
      original.Description = editBurger.Description != null ? editBurger.Description : original.Description;
      original.Price = editBurger.Price > 0 ? editBurger.Price : original.Price;
      return _repo.Edit(original);
   }
   //Remove
   public Burger Delete(int id)
   {
    //  Burger burgerToRemove = FAKEDB.Burgers.Find(c=>c.Id==id);
    Burger burgerToRemove = GetBurgerById(id);
     if(burgerToRemove==null)
     {
       throw new Exception("Invlid Id");
     }
     _repo.Delete(burgerToRemove);
    //  FAKEDB.Burgers.Remove(burgerToRemove);
     return burgerToRemove;
   }
  }
}