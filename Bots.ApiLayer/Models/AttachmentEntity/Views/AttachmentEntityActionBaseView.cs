namespace Bots.ApiLayer.Models.AttachmentEntity.Views
{
	public class AttachmentEntityActionBaseView
	{
		public AttachmentEntityActionBaseView()
		{
			destinationType = AttachmentEntityActionDestinationType.Regular;
		}

		public AttachmentEntityActionBaseView(AttachmentEntityActionDestinationType destinationTypeVal)
		{
			destinationType = destinationTypeVal;
		}

		public AttachmentEntityActionBaseView(string uid, AttachmentEntityActionType type, AttachmentEntityActionDestinationType destinationType)
		{
			this.uid = uid;
			this.type = type;
			this.destinationType = destinationType;
		}

		public AttachmentEntityActionDestinationType GetDestinationType()
		{
			return destinationType;
		}
		/// <summary>
		/// Идентификатор действия (понадобится вам для обработки выполнения действия)
		/// </summary>
		public string uid { get; set; }
		/// <summary>
		/// Тип действия
		/// </summary>
		public AttachmentEntityActionType type { get; set; }
		private AttachmentEntityActionDestinationType destinationType { get; set; }

	}
}