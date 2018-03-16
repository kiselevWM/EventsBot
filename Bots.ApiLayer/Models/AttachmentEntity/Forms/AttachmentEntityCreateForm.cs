using System.Collections.Generic;

namespace Bots.ApiLayer.Models.AttachmentEntity.Forms
{
	public class AttachmentEntityCreateForm : Base.AttachmentEntityBaseView
	{
		/// <summary>
		/// Интерактивные элементы
		/// </summary>
		public List<AttachmentEntityActionCreateForm> actions { get; set; }
	}
}