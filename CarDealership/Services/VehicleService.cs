using CarDealership.Data;
using CarDealership.Models;

namespace CarDealership.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly CarDbContext _context;
        public VehicleService(CarDbContext context) => _context = context;

        public int AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return vehicle.Id;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetVehicle(int Id)
        {
           var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == Id);
            return vehicle!;
        }
    }
}
