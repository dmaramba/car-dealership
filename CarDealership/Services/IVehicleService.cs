using CarDealership.Models;

namespace CarDealership.Services
{
    public interface IVehicleService
    {
        public int AddVehicle(Vehicle vehicle);
        public Vehicle GetVehicle(int Id);

        public List<Vehicle> GetAllVehicles();
    }
}
