namespace Bots.ApiLayer.Models.Post
{
	public class SharerDataForm
	{
		/// <summary>
		/// Строковый идентификатор сниппета, которые был получен при обращении к /api/utility/GetUrlDesc
		/// </summary>
		public string uid { get; set; }
		/// <summary>
		/// Урл страницы, который используется на странице шарера
		/// </summary>
		public string url { get; set; }
		/// <summary>
		/// Заголовок шарера
		/// </summary>
		public string title { get; set; }
		/// <summary>
		/// Описание страницы
		/// </summary>
		public string desc { get; set; }
		/// <summary>
		/// Выбранная картинка (если применимо)
		/// </summary>
		public string image { get; set; }
		/// <summary>
		/// Выбранное видео (если применимо)
		/// </summary>
		public SharerVideoDataForm video { get; set; }
	}
}