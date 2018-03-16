using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Event.Forms
{
	public class PostEventBaseForm : BasePostForm
	{
		/// <summary>
		///  Группа / Бизнес Страница, в которую происходит пост (если применимо)
		/// </summary>
		public string groupUid { get; set; }
	}
}