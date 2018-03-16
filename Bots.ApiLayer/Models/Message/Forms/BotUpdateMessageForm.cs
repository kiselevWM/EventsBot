using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Message.Forms
{
	public class BotUpdateMessageForm
	{
		public long messageId { get; set; }
		public string postText { get; set; }
		public List<AttachmentEntityCreateForm> attachedActions { get; set; }
		public List<AttachmentView> attachments { get; set; }
		public ShareDataUpdateForm share { get; set; }
	}
}