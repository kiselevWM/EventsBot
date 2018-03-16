using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.AttachmentEntity.Views;
using Bots.ApiLayer.Models.Share.Views;

namespace Bots.ApiLayer.Models.Message.Views
{
	public class MessageBaseView
	{
		public long id { get; set; }
		public string datecreated { get; set; }
		public string datecreatedstr { get; set; }
		public string cleanMessage { get; set; }
		public string message { get; set; }
		public IList<AttachmentView> attachments { get; set; }
		public ShareView share { get; set; }
		public bool seen { get; set; }
		/// <summary>
		/// Перечень действий с их описанием
		/// </summary>
		public List<AttachmentEntityView> attachedActions { get; set; }
	}
}