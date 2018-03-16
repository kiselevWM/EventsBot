using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.ApiLayer.Models.Message.Forms;
using Bots.ApiLayer.Models.Message.Views;

namespace Bots.ApiLayer.Api.Message
{
	public interface IMessageApi
	{
		Task<IEnumerable<MessageAdvancedView>> BotPostAsync(BotPostMessageForm form, TimeSpan? timeSpan = null);
		Task<MessageAdvancedView> BotUpdateAsync(BotUpdateMessageForm form, TimeSpan? timeSpan = null);
	}
}