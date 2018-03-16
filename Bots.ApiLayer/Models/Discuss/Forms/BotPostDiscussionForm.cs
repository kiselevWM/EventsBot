using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;

namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class BotPostDiscussionForm : PostDiscussionForm
	{
		/// <summary>
		/// Кнопки / действия
		/// </summary>
		public List<AttachmentEntityCreateForm> attachedActions { get; set; }
	}
}