using System;
using System.Collections.Generic;
using cburgerapi.db;
using cburgerapi.Models;

namespace cburgerapi.Services
{
  public class DrinksService
  {
    private readonly DrinkRepository _repo;
    public DrinksService(DrinkRepository repo)
    {
      _repo=repo;
    }
   // GetAll
   public IEnumerable<Drink> Get()
   {
     return _repo.GetAll();
   }
   //Get by Id
   public Drink GetDrinkById(int id)
   {
    //  Drink drinkToReturn = FAKEDB.Drinks.Find(c=> c.Id==id);
    Drink drinkToReturn = _repo.GetById(id);
     if(drinkToReturn==null)
     {
       throw new Exception("Invalid Id");
     }
     return drinkToReturn;
   }
   //Create
   public Drink Create(Drink newDrink)
   {
    //  FAKEDB.Drinks.Add(newDrink);
     return _repo.Create(newDrink);
   }
   //Edit
   public Drink Edit(Drink editDrink)
   {
    //  Drink foundDrink = FAKEDB.Drinks.Find(c=> c.Id==editDrink.Id);
    //  if(foundDrink==null)
    //  {
    //    throw new Exception("Invalid Id");
    //  }
    //  FAKEDB.Drinks.Remove(foundDrink);
    //  FAKEDB.Drinks.Add(editDrink);
    //  return editDrink;
    Drink original = GetDrinkById(editDrink.Id);
    original.Name = editDrink.Name != null ? editDrink.Name : original.Name;
      original.Description = editDrink.Description != null ? editDrink.Description : original.Description;
      original.Price = editDrink.Price > 0 ? editDrink.Price : original.Price;
      return _repo.Edit(original);
   }
   //Remove
   public Drink Delete(int id)
   {
    //  Drink drinkToRemove = FAKEDB.Drinks.Find(c=>c.Id==id);
    Drink drinkToRemove = GetDrinkById(id);
     if(drinkToRemove==null)
     {
       throw new Exception("Invlid Id");
     }
     _repo.Delete(drinkToRemove);
    //  FAKEDB.Burgers.Remove(burgerToRemove);
     return drinkToRemove;
   }
  }
}