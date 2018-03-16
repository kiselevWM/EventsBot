namespace Bots.ApiLayer.Models.AttachmentEntity.Base
{
    public class AttachmentEntityBaseView
    {
	    public AttachmentEntityBaseView(){}

	    public AttachmentEntityBaseView(string uid, string title, AttachmentEntityType type)
	    {
		    this.uid = uid;
		    this.title = title;
		    this.type = type;
	    }
		/// <summary>
		/// Идентификатор блока интерактивных действий (понадобится вам для обработки выполнения действия)
		/// </summary>
        public string uid { get; set; }
		/// <summary>
		/// Заголовок
		/// </summary>
        public string title { get; set; }
		/// <summary>
		/// Тип
		/// </summary>
        public AttachmentEntityType type { get; set; }
    }
}
