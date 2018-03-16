using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class BaseShortDiscussBotForm : BasePostForm
	{
		/// <summary>
		/// Идентификатор родительского комментария
		/// </summary>
		public long parentId { get; set; }
		/// <summary>
		/// Идентификатор события
		/// </summary>
		public long eventId { get; set; }
	}
}