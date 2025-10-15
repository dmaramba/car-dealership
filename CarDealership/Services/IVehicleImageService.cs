using CarDealership.Models;

namespace CarDealership.Services
{
    public interface IVehicleImageService
    {
        public void AddImage(VehicleImage image);

        public List<VehicleImage> GetVehicleImages(int vehicleId);
    }
}
