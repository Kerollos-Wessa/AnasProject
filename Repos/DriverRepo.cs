using AnasProject.Controllers;

namespace AnasProject.Repos
{
    public class DriverRepo : Repository<Driver>, IDriverRepo
    {
        Context context;
        public DriverRepo(Context _context) : base(_context)
        {
            this.context = _context;
        }

    }
}
