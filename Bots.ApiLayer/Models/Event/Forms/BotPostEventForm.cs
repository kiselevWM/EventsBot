using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class BotPostEventForm : PostEventForm
	{
		/// <summary>
		/// Кнопки / действия
		/// </summary>
		public List<AttachmentEntityCreateForm> attachedActions { get; set; }
	}
}