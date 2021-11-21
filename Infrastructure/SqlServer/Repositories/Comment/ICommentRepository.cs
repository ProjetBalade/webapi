using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public interface ICommentRepository
    {
        List<Domain.Comment> GetAll();

        Domain.Comment GetById(int id);

        Domain.Comment Create(Domain.Comment comment);

        bool Update(int id, Domain.Comment comment);

        bool Delete(int id);
    }
}