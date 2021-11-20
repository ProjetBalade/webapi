using System.Collections.Generic;
using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment
{
    public class UseCaseGetAllComments : IQuery<List<OutputDtoComment>>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseGetAllComments(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public List<OutputDtoComment> Execute()
        {
            var comments = _commentRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoComment>>(comments);
        }
    }
}