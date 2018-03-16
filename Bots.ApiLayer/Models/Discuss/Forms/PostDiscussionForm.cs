using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Discuss.Forms
{
	public class PostDiscussionForm : BaseDiscussPostForm
	{
		/// <summary>
		/// От чьего имени делать пост?
		/// </summary>
		public PostAuthor? author { get; set; }
		/// <summary>
		/// Данные со страницы шарера
		/// </summary>
		public SharerDataForm sharer { get; set; }
		/// <summary>
		/// Настройки направленного комментария
		/// </summary>
		public DirectedAccessForm directedAccess { get; set; }
	}
}