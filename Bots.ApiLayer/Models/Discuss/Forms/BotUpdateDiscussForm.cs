using System.Collections.Generic;
using Bots.ApiLayer.Models.AttachmentEntity.Forms;

namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class BotUpdateDiscussForm: UpdateDiscussForm
	{
		 /// <summary>
        /// Кнопки / действия (только для ботов)
        /// </summary>
        public List<AttachmentEntityCreateForm> attachedActions { get; set; }
	}
}