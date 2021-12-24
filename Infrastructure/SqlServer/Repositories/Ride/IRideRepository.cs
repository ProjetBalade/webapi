using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Ride
{
    public interface IRideRepository
    {
            List<Domain.Ride> GetAll();
            List<Domain.Ride> GetAllPending();
            Domain.Ride Create(int id,Domain.Ride ride);

            Domain.Ride Update(int id, Domain.Ride ride);
            void Delete(int id);
            
            Domain.Ride GetById(int id);


    }
}