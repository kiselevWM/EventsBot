using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotEvents;
using Bots.Common.ExternelModels.Requests.BotEvents.PostChatMessage;
using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupDiscuss;
using Bots.Common.ExternelModels.Requests.BotEvents.PostGroupEvent;
using Bots.Common.ExternelModels.Requests.BotEvents.PostMessage;
using Bots.Common.ExternelModels.Responses.BotEvents;
using Bots.Common.ExternelModels.Responses.BotEvents.Message;
using Bots.Common.ExternelModels.Responses.BotEvents.PostChatMessage;
using Bots.Common.ExternelModels.Responses.BotEvents.PostGroupDiscuss;

namespace Bots.Common.RequestProcessors.Events
{
	public abstract class BaseEventsProcessor: IEventsProcessor
	{
		/// <summary>
		/// group comment with task
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<PostGroupDicussWithTaskRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// group comment
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<PostGroupDicussRequest> request)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// update comment
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupDicussRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// update comment with task
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupDicussWithTaskRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// post group event
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<PostGroupEventRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// post group event with task
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<PostGroupEventWithTaskRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// update group event
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupEventRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// update group event with task
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupEventWithTaskRequest> arg)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// message
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostMessageResponse>> ProcessAsync(BaseEventsBotRequest<PostMessageRequest> request)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// chat message 
		/// </summary>
		public virtual Task<BaseEventsBotResponse<PostChatMessageResponse>> ProcessAsync(BaseEventsBotRequest<PostChatMessageRequest> request)
		{
			throw new NotImplementedException();
		}
	}
}