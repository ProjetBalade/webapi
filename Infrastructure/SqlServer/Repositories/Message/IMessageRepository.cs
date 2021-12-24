using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Message
{
    public interface IMessageRepository
    {
        List<Domain.Message> GetAll(int idReceiver);
        Domain.Message Create(Domain.Message message, int idSender);

        Domain.Message Update(int id, Domain.Message message);
        void Delete(int id);
            
        Domain.Message GetById(int id);
    }
}