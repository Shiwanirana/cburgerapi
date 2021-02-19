using System;
using System.ComponentModel.DataAnnotations;

namespace cburgerapi.Models
{
  public class Drink
  {
    [Required]
    public string Name {get;set;}
    
    [Range(0,100)]
    public int Price{get;set;}
    
    [MaxLength(80)]
    public string Description{get;set;}
    public int Id { get; set; } 
  }
}