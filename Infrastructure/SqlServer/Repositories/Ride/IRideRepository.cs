using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Ride
{
    public interface IRideRepository
    {
            List<Domain.Ride> GetAll();
            Domain.Ride Create(Domain.Ride ride);
        
    }
}