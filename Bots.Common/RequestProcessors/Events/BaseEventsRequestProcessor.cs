using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Discuss;
using Bots.ApiLayer.Api.Message;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotEvents;
using Bots.Common.ExternelModels.Requests.BotEvents.PostChatMessage;
using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupDiscuss;
using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupEvent;
using Bots.Common.ExternelModels.Requests.BotEvents.PostMessage;
using Bots.Common.ExternelModels.Responses.BotEvents;
using Bots.Common.ExternelModels.Responses.BotEvents.Message;
using Bots.Common.ExternelModels.Responses.BotEvents.PostChatMessage;
using Bots.Common.ExternelModels.Responses.BotEvents.PostGroupDiscuss;
using Bots.Common.Models.Events;
using Bots.Common.RequestProcessors.Base;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Events
{
	/// <summary>
	/// Can be singleton
	/// </summary>
	public class BaseEventsRequestProcessor: 
		BaseCustomRequestProcessor<BaseEventsBotRequest<JToken>, BaseEventsBotResponse<IBotEventsResponseBody>, IBotEventsResponseBody>
	{
		public override BotRequestType RequestType => BotRequestType.BotEvent;
		private readonly Dictionary<BotEvent, Func<BaseEventsBotRequest<JToken>, Task<BaseEventsBotResponse<IBotEventsResponseBody>>>> _eventProcessors;
		protected BaseEventsRequestProcessor(IEventsProcessor eventsProcessor) 
		{
			_eventProcessors = new Dictionary<BotEvent, Func<BaseEventsBotRequest<JToken>, Task<BaseEventsBotResponse<IBotEventsResponseBody>>>>
			{
				{
					BotEvent.PostedGroupTaskComment, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostGroupDicussWithTaskRequest>, PostGroupDicussWithTaskRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.PostedGroupComment, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostGroupDicussRequest>, PostGroupDicussRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync), request.token)
				},
				{
					BotEvent.UpdatedGroupComment, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<UpdateGroupDicussRequest>, UpdateGroupDicussRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.UpdatedGroupTaskComment, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<UpdateGroupDicussWithTaskRequest>, UpdateGroupDicussWithTaskRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.PostedGroupEvent, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostGroupEventRequest>, PostGroupEventRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.PostedGroupTaskEvent, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostGroupEventWithTaskRequest>, PostGroupEventWithTaskRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.UpdatedGroupEvent, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<UpdateGroupEventRequest>, UpdateGroupEventRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.UpdatedGroupTaskEvent, async request =>
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<UpdateGroupEventWithTaskRequest>, UpdateGroupEventWithTaskRequest, 
							BaseEventsBotResponse<PostGroupDicussResponse>, PostGroupDicussResponse>(request, CreateRequest, eventsProcessor.ProcessAsync),
						request.token)
				},
				{
					BotEvent.Message, async request => 
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostMessageRequest>, PostMessageRequest, 
							BaseEventsBotResponse<PostMessageResponse>, PostMessageResponse>(request, CreateRequest, 
							eventsProcessor.ProcessAsync), request.token)
				},
				{
					BotEvent.ChatMessage, async request => 
						CastResponse(
						await ProcessWrapper<BaseEventsBotRequest<PostChatMessageRequest>, PostChatMessageRequest, 
							BaseEventsBotResponse<PostChatMessageResponse>, PostChatMessageResponse>(request, CreateRequest, 
							eventsProcessor.ProcessAsync), request.token)
				}
			};
		}
		
		private static BaseEventsBotRequest<TRequestBody> CreateRequest<TRequestBody>(BaseEventsBotRequest<JToken> request, TRequestBody requestBody)
		{
			return new BaseEventsBotRequest<TRequestBody>(request.botEvent, requestBody, request.lng, request.token);
		}
		protected BaseEventsBotResponse<IBotEventsResponseBody> CastResponse<TResponseBody>(BaseEventsBotResponse<TResponseBody> response, 
			string token) where TResponseBody : IBotEventsResponseBody
		{
			return response == null ? null : new BaseEventsBotResponse<IBotEventsResponseBody>(response.response, token);
		}

		protected override bool TryGetProcessor(BaseEventsBotRequest<JToken> request, 
			out Func<BaseEventsBotRequest<JToken>, Task<BaseEventsBotResponse<IBotEventsResponseBody>>> func)
		{
			return _eventProcessors.TryGetValue(request.botEvent, out func);
		}
	}
}