using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class VehicleImageService : IVehicleImageService
    {

        private readonly CarDbContext _context;
        public VehicleImageService(CarDbContext context) => _context = context;
        public void AddImage(VehicleImage image)
        {
            _context.VehicleImages.Add(image);
            _context.SaveChanges();
        }

        public List<VehicleImage> GetVehicleImages(int vehicleId)
        {
            return _context.VehicleImages.Where(x => x.VehicleId == vehicleId).ToList();
        }
    }
}
