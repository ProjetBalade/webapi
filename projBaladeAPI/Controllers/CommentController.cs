
using System.Collections.Generic;
using Application.UseCases.Comment;
using Application.UseCases.Comment.Dtos;
using Domain;
using Infrastructure.SqlServer.Repositories.Comment;
using Microsoft.AspNetCore.Mvc;

namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseCreateComment _useCaseCreateComment;

        private readonly UseCaseGetAllComments _useCaseGetAllComments;

        private ICommentRepository _commentRepository;
        
        public CommentController(
            UseCaseCreateComment useCaseCreateComment,
            UseCaseGetAllComments useCaseGetAllComments,
            ICommentRepository commentRepository)
        {
            _useCaseCreateComment = useCaseCreateComment;
            _useCaseGetAllComments = useCaseGetAllComments;
            _commentRepository = commentRepository;
        }
        
        [HttpGet]
        public ActionResult<List<OutputDtoComment>> GetAll()
        {
            return _useCaseGetAllComments.Execute();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]

        public ActionResult<OutputDtoComment> Create(InputDtoCreateComment dto)
        {
            return StatusCode(201, _useCaseCreateComment.Execute(dto));
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Update(int id, Comment comment)
        {
            if (_commentRepository.Update(id, comment))
            {
                return Ok();
            }

            return NotFound();
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_commentRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}