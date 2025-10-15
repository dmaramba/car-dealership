using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class VehicleImage
    {
        [Key]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string FileName { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
