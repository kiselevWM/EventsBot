using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotActions;
using Bots.Common.ExternelModels.Requests.BotActions.Discuss;
using Bots.Common.ExternelModels.Requests.BotActions.Event;
using Bots.Common.ExternelModels.Requests.BotActions.Message;
using Bots.Common.ExternelModels.Responses.BotActions;
using Bots.Common.ExternelModels.Responses.BotActions.Discuss;
using Bots.Common.ExternelModels.Responses.BotActions.Event;
using Bots.Common.ExternelModels.Responses.BotActions.Message;

namespace Bots.Common.RequestProcessors.Actions
{
	public interface IActionsProcessor
	{
		Task<BaseActionsBotResponse<MessageActionBotResponse>> ProcessAsync(
			BaseActionsBotRequest<MessageActionBotRequest> request);

		Task<BaseActionsBotResponse<DiscusActionBotResponse>> ProcessAsync(
			BaseActionsBotRequest<DiscusActionBotRequest> request);

		Task<BaseActionsBotResponse<EventActionBotResponse>> ProcessAsync(
			BaseActionsBotRequest<EventActionBotRequest> request);
	}
}