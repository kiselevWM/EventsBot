using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;

namespace Bots.ApiLayer.Models.Message.Forms
{
	public class BotPostMessageForm : PostMessageForm
	{
		/// <summary>
		/// Кнопки / действия
		/// </summary>
		public List<AttachmentEntityCreateForm> attachedActions { get; set; }
	}
}