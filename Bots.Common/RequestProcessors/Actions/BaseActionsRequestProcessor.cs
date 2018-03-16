using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Discuss;
using Bots.ApiLayer.Api.Event;
using Bots.ApiLayer.Api.Message;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotActions;
using Bots.Common.ExternelModels.Requests.BotActions.Discuss;
using Bots.Common.ExternelModels.Requests.BotActions.Event;
using Bots.Common.ExternelModels.Requests.BotActions.Message;
using Bots.Common.ExternelModels.Responses.BotActions;
using Bots.Common.ExternelModels.Responses.BotActions.Discuss;
using Bots.Common.ExternelModels.Responses.BotActions.Event;
using Bots.Common.ExternelModels.Responses.BotActions.Message;
using Bots.Common.RequestProcessors.Base;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Actions
{
	/// <summary>
	/// Can be singleton
	/// </summary>
	public abstract class BaseActionsRequestProcessor
		: BaseCustomRequestProcessor<BaseActionsBotRequest<JToken>, BaseActionsBotResponse<IBotActionsResponseBody>, IBotActionsResponseBody>
	{
		public override BotRequestType RequestType => BotRequestType.BotAction;

		private readonly
			Dictionary<BotActionContextType,
				Func<BaseActionsBotRequest<JToken>, Task<BaseActionsBotResponse<IBotActionsResponseBody>>>> _processors;
		protected BaseActionsRequestProcessor(IActionsProcessor actionsProcessor)
		{
			_processors = new Dictionary<BotActionContextType, Func<BaseActionsBotRequest<JToken>, Task<BaseActionsBotResponse<IBotActionsResponseBody>>>>
			{
				{
					BotActionContextType.Message, async request => 
					CastResponse(
					await ProcessWrapper<BaseActionsBotRequest<MessageActionBotRequest>, MessageActionBotRequest, 
						BaseActionsBotResponse<MessageActionBotResponse>, MessageActionBotResponse>(request, CreateRequest, actionsProcessor.ProcessAsync),
					request.token)
				},
				{
					BotActionContextType.Discuss, async request => 
					CastResponse(
					await ProcessWrapper<BaseActionsBotRequest<DiscusActionBotRequest>, DiscusActionBotRequest, 
						BaseActionsBotResponse<DiscusActionBotResponse>, DiscusActionBotResponse>(request, CreateRequest, actionsProcessor.ProcessAsync),
					request.token)
				},
				{
					BotActionContextType.Event, async request => 
					CastResponse(
					await ProcessWrapper<BaseActionsBotRequest<EventActionBotRequest>, EventActionBotRequest, 
						BaseActionsBotResponse<EventActionBotResponse>, EventActionBotResponse>(request, CreateRequest, actionsProcessor.ProcessAsync),
					request.token)
				}
			};
		}

		protected override bool TryGetProcessor(BaseActionsBotRequest<JToken> request, out Func<BaseActionsBotRequest<JToken>, Task<BaseActionsBotResponse<IBotActionsResponseBody>>> func)
		{
			return _processors.TryGetValue(request.contextType, out func);
		}

		private BaseActionsBotResponse<IBotActionsResponseBody> CastResponse<TResponseBody>(BaseActionsBotResponse<TResponseBody> response, string token) 
			where TResponseBody : IBotActionsResponseBody
		{
			return response == null ? null : new BaseActionsBotResponse<IBotActionsResponseBody>(response.response, token);
		}

		private static BaseActionsBotRequest<TRequestBody> CreateRequest<TRequestBody>(BaseActionsBotRequest<JToken> request, TRequestBody requestBody)
		{
			return new BaseActionsBotRequest<TRequestBody>(request.attachmentUid, request.actionUid, request.userWmid, requestBody, 
				request.lng, request.token, request.contextType);
		}
	}
}