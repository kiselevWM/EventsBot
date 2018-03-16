using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class BotEventUpdateForm: EventUpdateForm
	{
		/// <summary>
        /// Кнопки / действия
        /// </summary>
        public List<AttachmentEntityCreateForm> attachedActions { get; set; }
	}
}