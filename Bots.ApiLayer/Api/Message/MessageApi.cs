using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Base;
using Bots.ApiLayer.Models.Message.Forms;
using Bots.ApiLayer.Models.Message.Views;

namespace Bots.ApiLayer.Api.Message
{
	public class MessageApi: BaseWebApi, IMessageApi
	{
		public MessageApi(string token, string apiUrl = null) : base(token, apiUrl){}
		protected override string Controller => "Message";
		public async Task<IEnumerable<MessageAdvancedView>> BotPostAsync(BotPostMessageForm form, TimeSpan? timeSpan = null)
		{
			if (form == null) return null;
			return await SendPostRequest<BotPostMessageForm, List<MessageAdvancedView>>("BotPost", form, timeSpan).ConfigureAwait(false);
		}

		public async Task<MessageAdvancedView> BotUpdateAsync(BotUpdateMessageForm form, TimeSpan? timeSpan = null)
		{
			if (form == null) return null;
			return await SendPostRequest<BotUpdateMessageForm, MessageAdvancedView>("BotUpdate", form, timeSpan).ConfigureAwait(false);
		}
	}
}