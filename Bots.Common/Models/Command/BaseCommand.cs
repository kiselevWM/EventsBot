using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotCommands;
using Bots.Common.ExternelModels.Requests.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.EventCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using Bots.Common.ExternelModels.Responses.BotCommands;
using Bots.Common.ExternelModels.Responses.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.EventCommand;
using Bots.Common.ExternelModels.Responses.BotCommands.MessageCommand;

namespace Bots.Common.Models.Command
{
	public abstract class BaseCommand: ICommand
	{
		public abstract string UniqueName { get; }
		public virtual Task<BaseCommandBotResponse<IMessageCommandResponse>> ExecAsync(BaseCommandBotRequest<MessageCommandBotRequest> request)
		{
			throw new System.NotImplementedException();
		}

		public virtual Task<BaseCommandBotResponse<IDiscussCommandResponse>> ExecAsync(BaseCommandBotRequest<DiscussCommandBotRequest> request)
		{
			throw new System.NotImplementedException();
		}

		public virtual Task<BaseCommandBotResponse<IEventCommandResponse>> ExecAsync(BaseCommandBotRequest<EventCommandBotRequest> request)
		{
			throw new System.NotImplementedException();
		}
	}
}