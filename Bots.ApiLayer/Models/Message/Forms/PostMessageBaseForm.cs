using Bots.ApiLayer.Models.Post;

namespace Bots.ApiLayer.Models.Message.Forms
{
	public class PostMessageBaseForm: BasePostForm
	{
		public long? parentId { get; set; }
	}
}
