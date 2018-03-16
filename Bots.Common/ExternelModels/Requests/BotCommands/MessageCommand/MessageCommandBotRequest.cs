
namespace Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand
{
	public class MessageCommandBotRequest : CommandCommonBotRequest
	{
		public MessageCommandBotRequest(){}
		public MessageCommandBotRequest(string message) : base(message){}
	}
}