using Bots.Common.ExternelModels.Requests.BotEvents.PostMessage;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostChatMessage
{
	public class PostChatMessageRequest: PostMessageRequest
	{
		public string chatUid { get; set; }
	}
}
