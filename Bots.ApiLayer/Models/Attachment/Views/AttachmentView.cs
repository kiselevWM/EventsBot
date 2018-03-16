namespace Bots.ApiLayer.Models.Attachment.Views
{
	public class AttachmentView : AttachmentBaseView
	{      
		//файл или картинка
		public UploadedType type { get; set; }
		public AttachmentType typeAdditionally { get; set; }
	}
}