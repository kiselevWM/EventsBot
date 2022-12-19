using Bots.ApiLayer.Models.Chat.Forms;
using Bots.ApiLayer.Models.Message.Views;
using System;
using System.Threading.Tasks;

namespace Bots.ApiLayer.Api.Chat
{
	public interface IChatApi
	{
		Task<MessageAdvancedView> PostMessageAsync(ChatMessagePostForm form, TimeSpan? timeSpan = null);
	}
}
