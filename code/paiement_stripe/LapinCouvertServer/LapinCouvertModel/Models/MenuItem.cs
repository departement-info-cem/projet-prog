using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LapinCouvertModels.Interfaces;

namespace LapinCouvertModels.Models;

public class MenuItem : IModel
{
    public int Id { get; set; }
    
    [MaxLength(255)]
    public required string Name { get; set; }
    
    public required float Price { get; set; }
    
    public required int Quantity { get; set; }
    
    [MaxLength(255)]
    public string ImageUrl { get; set; } = "";
}