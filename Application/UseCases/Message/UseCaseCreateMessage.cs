using Application.UseCases.Message.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Message;

namespace Application.UseCases.Message
{
    public class UseCaseCreateMessage : IWriting<OutputDtoMessage, InputDtoMessage>
    {
        private readonly IMessageRepository _messageRepository;

        public UseCaseCreateMessage(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public OutputDtoMessage Execute(InputDtoMessage dto)
        {
            throw new System.NotImplementedException();
        }
        
        public OutputDtoMessage Execute(InputDtoMessage dto, int idSender)
        {
            var messageFromDto = Mapper.GetInstance().Map<Domain.Message>(dto);

            var messageFromDb = _messageRepository.Create(messageFromDto, idSender);

            return Mapper.GetInstance().Map<OutputDtoMessage>(messageFromDb);
            
        }
        
    }
}