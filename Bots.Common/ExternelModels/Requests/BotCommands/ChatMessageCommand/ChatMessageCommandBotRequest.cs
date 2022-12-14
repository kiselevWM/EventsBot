using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using System;

namespace Bots.Common.ExternelModels.Requests.BotCommands.ChatMessageCommand
{
	public class ChatMessageCommandBotRequest: MessageCommandBotRequest
	{
		public ChatMessageCommandBotRequest(){}
		public ChatMessageCommandBotRequest(string message, string chatUid): base(message)
		{
			this.chatUid = chatUid ?? throw new ArgumentNullException(nameof(chatUid));
		}
		public string chatUid { get; set; }
	}
}
