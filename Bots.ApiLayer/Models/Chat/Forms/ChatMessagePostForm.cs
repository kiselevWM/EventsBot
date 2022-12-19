using Bots.ApiLayer.Models.Message.Forms;

namespace Bots.ApiLayer.Models.Chat.Forms
{
	public class ChatMessagePostForm: PostMessageBaseForm
	{
        public string chatUid { get; set; }
	}
}
