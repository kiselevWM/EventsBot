namespace Bots.ApiLayer.Models.Post
{
	public class SharerVideoDataForm
	{
		/// <summary>
		/// Идентификатор видео (из youtube, vimeo, или coub)
		/// </summary>
		public string id { get; set; }
		public ShareUrlMediaType type { get; set; }
	}
}