using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using System;

namespace Bots.Common.ExternelModels.Requests.BotCommands.ChatMessageCommand
{
	public class ChatMessageCommandBotRequest: MessageCommandBotRequest
	{
		public ChatMessageCommandBotRequest(){}
		public ChatMessageCommandBotRequest(string message,long? parentMessageId, string chatUid): base(message, parentMessageId)
		{
			this.chatUid = chatUid ?? throw new ArgumentNullException(nameof(chatUid));
		}
		public string chatUid { get; set; }
	}
}
