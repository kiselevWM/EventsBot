using Bots.Common.ExternelModels.Responses.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.EventCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.MessageCommand;

namespace Bots.Common.ExternelModels.Responses.BotCommands
{
	public class BotCommandStateResponse : IDiscussCommandResponse, IEventCommandResponse, IMessageCommandResponse
	{
		public BotCommandStateResponse(){}
		public BotCommandStateResponse(string message, BotCommandStateType state)
		{
			this.message = message;
			this.state = state;
		}
		public string message { get; set; }
		public BotCommandStateType state { get; set; }
	}
}