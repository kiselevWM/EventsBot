using System;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Base;
using Bots.ApiLayer.Models.Chat.Forms;
using Bots.ApiLayer.Models.Message.Views;

namespace Bots.ApiLayer.Api.Chat
{
	public class ChatApi : BaseWebApi, IChatApi
	{
		public ChatApi(string token, string apiUrl = null) : base(token, apiUrl){}
		protected override string Controller => "Chat";

		public async Task<MessageAdvancedView> PostMessageAsync(ChatMessagePostForm form, TimeSpan? timeSpan = null)
		{
			if (form == null) return null;
			return await SendPostRequest<ChatMessagePostForm, MessageAdvancedView>("PostMessage", form, timeSpan).ConfigureAwait(false);
		}
	}
}
