using System.Collections.Generic;
using Application.UseCases.Message.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Message;

namespace Application.UseCases.Message
{
    public class UseCaseGetAllMessage : IQuery<List<OutputDtoMessage>>
    {
        private readonly IMessageRepository _messageRepository;
        
        public UseCaseGetAllMessage(IMessageRepository messageRepository)
        {
            _messageRepository= messageRepository;
        }
        public List<OutputDtoMessage> Execute(int idSender)
        {
            var messages = _messageRepository.GetAll(idSender);

            return Mapper.GetInstance().Map<List<OutputDtoMessage>>(messages);
        }

        public List<OutputDtoMessage> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}