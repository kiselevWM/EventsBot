using Bots.ApiLayer.Models.AttachmentEntity.Base;

namespace Bots.ApiLayer.Models.AttachmentEntity.Views
{
	public class AttachmentEntityActionButtonView : AttachmentEntityActionButtonBaseView
	{
		public AttachmentEntityActionButtonView()
		{

		}

		public AttachmentEntityActionButtonView(AttachmentEntityActionButtonType buttonType)
			: base(buttonType)
		{ }

		public AttachmentEntityActionButtonView(AttachmentEntityActionButtonType buttonType, AttachmentEntityActionButtonStyle style, string text)
			: base(buttonType, style, text) { }

		public AttachmentEntityActionButtonView(AttachmentEntityActionButtonStyle style, string text)
			: base(style, text) { }

	}
}