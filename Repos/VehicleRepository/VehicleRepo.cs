using AnasProject.Models;

namespace AnasProject.Repos.VehicleRepository
{
    public class VehicleRepo:Repository<Vehicle> , IVehicleRepo
    {
        Context context;
        public VehicleRepo(Context _context) : base(_context)
        {
            context = _context;
        }


    }
}
