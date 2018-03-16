using System;
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
	public abstract class BaseActionsProcessor: IActionsProcessor
	{
		public virtual Task<BaseActionsBotResponse<MessageActionBotResponse>> ProcessAsync(
			BaseActionsBotRequest<MessageActionBotRequest> request)
		{
			throw new NotImplementedException();
		}
		public virtual Task<BaseActionsBotResponse<DiscusActionBotResponse>> ProcessAsync(BaseActionsBotRequest<DiscusActionBotRequest> request)
		{
			throw new NotImplementedException();
		}
		public virtual Task<BaseActionsBotResponse<EventActionBotResponse>> ProcessAsync(BaseActionsBotRequest<EventActionBotRequest> request)
		{
			throw new NotImplementedException();
		}
	}
}