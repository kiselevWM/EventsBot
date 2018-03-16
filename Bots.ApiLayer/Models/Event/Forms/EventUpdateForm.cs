using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class EventUpdateForm: EventIdentForm
	{
		public string message { get; set; }
        public List<AttachmentView> attachments { get; set; }
        public ShareDataUpdateForm share { get; set; }
	}
}