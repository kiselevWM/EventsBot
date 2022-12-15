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
	public interface IEventsProcessor
	{
		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<PostGroupDicussWithTaskRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<PostGroupDicussRequest> request);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupDicussRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<UpdateGroupDicussWithTaskRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<PostGroupEventRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<PostGroupEventWithTaskRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(BaseEventsBotRequest<UpdateGroupEventRequest> arg);

		Task<BaseEventsBotResponse<PostGroupDicussResponse>> ProcessAsync(
			BaseEventsBotRequest<UpdateGroupEventWithTaskRequest> arg);

		Task<BaseEventsBotResponse<PostMessageResponse>> ProcessAsync(BaseEventsBotRequest<PostMessageRequest> request);
		Task<BaseEventsBotResponse<PostChatMessageResponse>> ProcessAsync(BaseEventsBotRequest<PostChatMessageRequest> request);
	}
}