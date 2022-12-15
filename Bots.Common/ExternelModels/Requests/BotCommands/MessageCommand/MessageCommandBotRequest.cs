
namespace Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand
{
	public class MessageCommandBotRequest : CommandCommonBotRequest
	{
		public MessageCommandBotRequest(){}
		public MessageCommandBotRequest(string message, long? parentMessageId) : base(message)
		{
			this.parentMessageId = parentMessageId;
		}
		public long? parentMessageId { get; set; }
	}
}