using Bots.Common.ExternelModels.Responses.BotEvents.Message;

namespace Bots.Common.ExternelModels.Responses.BotEvents.PostChatMessage
{
	public class PostChatMessageResponse: PostMessageResponse
	{
		/// <summary>
		/// Uid беседы
		/// </summary>
		public string chatUid { get; set; }
	}
}
