namespace Bots.ApiLayer.Models.AttachmentEntity.Base
{
	public class AttachmentEntityActionButtonBaseView
	{
		public AttachmentEntityActionButtonBaseView()
		{
			buttonTypeVal = AttachmentEntityActionButtonType.Regular;
		}
		public AttachmentEntityActionButtonBaseView(AttachmentEntityActionButtonType buttonType)
		{
			buttonTypeVal = buttonType;
		}

		public AttachmentEntityActionButtonBaseView(AttachmentEntityActionButtonType buttonType, AttachmentEntityActionButtonStyle style, string text)
			: this(buttonType)
		{
			this.style = style;
			this.text = text;
		}

		public AttachmentEntityActionButtonBaseView(AttachmentEntityActionButtonStyle style, string text)
			: this()
		{
			this.style = style;
			this.text = text;
		}

		public AttachmentEntityActionButtonType GetButtonType()
		{
			return buttonTypeVal;
		}
		/// <summary>
		/// Текст кнопки
		/// </summary>
		public string text { get; set; }
		private AttachmentEntityActionButtonType buttonTypeVal { get; set; }
		//public AttachmentEntityActionButtonType buttonType { get; set; }
		/// <summary>
		/// стиль кнопки
		/// </summary>
		public AttachmentEntityActionButtonStyle style { get; set; }
	}
}