using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Base;

namespace Bots.ApiLayer.Models.AttachmentEntity.Views
{
	public class AttachmentEntityView : AttachmentEntityBaseView
	{
		public string dateCreated { get; set; }
		public string dateCreatedStr { get; set; }
		public List<AttachmentEntityActionView> actions { get; set; }
	}
}