using System.Collections.Generic;
using Bots.ApiLayer.Models.Attachment.Views;
using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class UpdateDiscussForm
	{
		/// <summary>
        /// Идентификатор комментария
        /// </summary>
        public long discussId { get; set; }
        public string groupUid { get; set; }
        public List<AttachmentView> attachments { get; set; }
        public ShareDataUpdateForm share { get; set; }
        public string message { get; set; }
	}
}